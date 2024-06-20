using TerceiroSetor.DTOs.Shared.Commands;

namespace TerceiroSetor.DTOs.Shared
{
    public class CredorDTO
    {
        public TipoCredorDTO TipoCredor { get; set; }
        public string NumeroInscricao { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoCommand Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
