using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.Attributes;

namespace TerceiroSetor.DTOs.Shared
{
    public class CnpjDTO
    {
        [Required]
        [Cnpj]
        [DisplayName("CNPJ")]
        public string Numero { get; set; } = string.Empty;
    }

}
