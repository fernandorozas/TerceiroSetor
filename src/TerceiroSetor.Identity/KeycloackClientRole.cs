using Newtonsoft.Json;

namespace TerceiroSetor.Identity
{
    public class KeycloackClientRole
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("containerId")]
        public Guid ContainerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("composite")]
        public bool Composite { get; set; }

        [JsonProperty("clientRole")]
        public bool ClientRole { get; set; }

    }

}
