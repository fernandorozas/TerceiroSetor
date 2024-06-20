using System.Text.Json.Serialization;

namespace TerceiroSetor.Domain.Entities
{
    public abstract class EntidadeFixa
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
