namespace TerceiroSetor.Identity
{
    public class IdentitySettings
    {
        public string Authority { get; set; } = string.Empty;
        public string KeycloakEndpoint { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string UserMaster { get; set; } = string.Empty;
        public string PasswordMaster { get; set; } = string.Empty;

    }
}
