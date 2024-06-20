using Newtonsoft.Json;
using System.Text;
using TerceiroSetor.Application.Gateways;
using TerceiroSetor.Domain.Entities;

namespace TerceiroSetor.Identity
{
    internal class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IdentitySettings _settings;

        public IdentityService(IdentitySettings settings)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(settings.KeycloakEndpoint);
            _settings = settings;

        }

        private async Task<string> GetMasterAcessTokenAsync()
        {

            var data = new Dictionary<string, string>()
            {
                {"grant_type", "password" },
                {"client_id", "admin-cli" },
                {"username", _settings.UserMaster },
                {"password", _settings.PasswordMaster }
            };

            var form = new FormUrlEncodedContent(data);
            var response = await _httpClient.PostAsync("realms/master/protocol/openid-connect/token", form);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);

            return tokenResponse?.access_token ?? "";
        }
        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            var token = await GetMasterAcessTokenAsync();
            if (!_httpClient.DefaultRequestHeaders.Any(x => x.Key == "Authorization"))
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.GetAsync("/admin/realms/intedatadigital/users");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<IdentityUser>>(content) ?? new List<IdentityUser>();

            foreach (var user in users)
            {
                var rolesResponse = await _httpClient.GetAsync($"/admin/realms/intedatadigital/users/{user.Id}/role-mappings/clients/{_settings.ClientId}");
                var rolesContent = await rolesResponse.Content.ReadAsStringAsync();
                user.GetRoles(rolesContent);

                var groupResponse = await _httpClient.GetAsync($"/admin/realms/intedatadigital/users/{user.Id}/groups");
                var groupContent = await groupResponse.Content.ReadAsStringAsync();
                user.GetGroups(groupContent);

            }

            var group = _settings.Client.Replace("-", " ").ToLower();

            var usersGroup = users.Where(x => x.Groups.Any(y => y.Name.ToLower() == group)).ToList();

            return usersGroup ?? new List<IdentityUser>();
        }
        public async Task<string> AddUser(IdentityUser user)
        {
            var groups = user.Groups.Select(x => x.Name);
            var userRoles = user.Roles.Select(x => x.Name);
            var clientRoles = new Dictionary<string, IEnumerable<string>>()
            {
                { _settings.Client, userRoles }
            };
            var credentials = new List<Dictionary<string, object>>();
            var password = new Dictionary<string, object>()
            {
                { "type", "password" },
                { "value", user.FirstName.Substring(0, 3) + "@" + DateTime.Now.Year.ToString() },
                { "temporary", true }
            };

            credentials.Add(password);

            var requiredActions = new List<string>() { "UPDATE_PASSWORD", "VERIFY_EMAIL" };
            var attibutes = new Dictionary<string, IEnumerable<string>>();
            attibutes.Add("picture", user.Attributes.Picture);
            attibutes.Add("tenants", user.Attributes.Tenant);

            var keycloackUser = new Dictionary<string, object>();
            keycloackUser.Add("firstName", user.FirstName);
            keycloackUser.Add("username", user.UserName);
            keycloackUser.Add("email", user.Email);
            keycloackUser.Add("enabled", true);
            keycloackUser.Add("emailVerified", false);
            keycloackUser.Add("clientRoles", clientRoles);
            keycloackUser.Add("groups", groups);
            keycloackUser.Add("requiredActions", requiredActions);
            keycloackUser.Add("attributes", attibutes);
            keycloackUser.Add("credentials", credentials);

            var json = JsonConvert.SerializeObject(keycloackUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var token = await GetMasterAcessTokenAsync();
            if (!_httpClient.DefaultRequestHeaders.Any(x => x.Key == "Authorization"))
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await _httpClient.PostAsync("/admin/realms/intedatadigital/users", data);

            if (response.IsSuccessStatusCode)
            {
                var location = response.Headers.GetValues("Location");
                var userId = location.FirstOrDefault()?
                    .Replace("/admin/realms/intedatadigital/users", "")
                    .Replace(_httpClient.BaseAddress.ToString(), "");


                var roleResponse = await _httpClient.GetAsync($"/admin/realms/intedatadigital/clients/{_settings.ClientId}/roles/{userRoles.FirstOrDefault()}");
                var roleContent = await roleResponse.Content.ReadAsStringAsync();
                var role = JsonConvert.DeserializeObject<KeycloackClientRole>(roleContent) ?? throw new ArgumentNullException();
                var roles = new List<KeycloackClientRole>();
                roles.Add(role);

                var roleJson = JsonConvert.SerializeObject(roles);
                var dataRole = new StringContent(roleJson, Encoding.UTF8, "application/json");
                await _httpClient.PostAsync($"/admin/realms/intedatadigital/users/{userId}/role-mappings/clients/{_settings.ClientId}", dataRole);

                return string.Empty;
            }

            var errorString = await response.Content.ReadAsStringAsync();
            var errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(errorString) ?? [];

            return errorJson["errorMessage"];

        }
        public async Task Logout(string refreshToken)
        {
            var data = new Dictionary<string, string>()
            {
                {"client_id", _settings.Client },
                {"client_secret", _settings.Secret },
                {"refresh_token", refreshToken }
            };

            var form = new FormUrlEncodedContent(data);
            var res = await _httpClient.PostAsync("realms/intedatadigital/protocol/openid-connect/logout", form);

            await Console.Out.WriteLineAsync(await res.Content.ReadAsStringAsync());
        }
        public async Task<string> UpdateProfile(Guid userId, string imageUrl, string nomeExibicao)
        {
            var attibutes = new Dictionary<string, IEnumerable<string>>();
            attibutes.Add("picture", new string[] { imageUrl });

            var keycloackUser = new Dictionary<string, object>();
            keycloackUser.Add("attributes", attibutes);
            keycloackUser.Add("firstName", nomeExibicao);

            var json = JsonConvert.SerializeObject(keycloackUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var token = await GetMasterAcessTokenAsync();

            if (!_httpClient.DefaultRequestHeaders.Any(x => x.Key == "Authorization"))
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await _httpClient.PutAsync($"/admin/realms/intedatadigital/users/{userId}", data);

            if (response.IsSuccessStatusCode)
                return string.Empty;

            var errorString = await response.Content.ReadAsStringAsync();
            var errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(errorString) ?? [];

            return "Ocorreu um erro na tentativa de atualização!";
        }

        public Task<IdentityUser> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task AddRole(IdentityUser user, string role)
        {
            throw new NotImplementedException();
        }

        public Task AddTenant(IdentityUser user, string tenant)
        {
            throw new NotImplementedException();
        }
    }
}
