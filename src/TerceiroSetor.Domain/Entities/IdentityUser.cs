using Newtonsoft.Json;

namespace TerceiroSetor.Domain.Entities
{
    public class IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public bool EmailVerified { get; set; }
        public string Email { get; set; } = string.Empty;
        public KeycloakAttributes Attributes { get; set; } = new KeycloakAttributes();
        public List<UserGroup> Groups { get; set; } = new List<UserGroup>();
        public List<UserRole> Roles { get; set; } = new List<UserRole>();

        public void GetGroups(string content)
        {
            this.Groups = JsonConvert.DeserializeObject<List<UserGroup>>(content)
                ?? new List<UserGroup>();
        }
        public void GetRoles(string content)
        {
            this.Roles = JsonConvert.DeserializeObject<List<UserRole>>(content)
                ?? new List<UserRole>();
        }

        public class KeycloakAttributes
        {
            public List<string> Tenant { get; set; } = new List<string>();
            public IEnumerable<string> Picture { get; set; } = new List<string>();
        }

        public class UserRole
        {
            public string Name { get; set; } = string.Empty;
        }

        public class UserGroup
        {
            public string Name { get; set; } = string.Empty;
        }


    }
}
