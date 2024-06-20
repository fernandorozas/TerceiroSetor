using TerceiroSetor.DTOs.Shared;

namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public class ConselhoMembroDTO 
    {
        public PessoaDTO Pessoa { get; set;}
        public DateTime InicioVigencia { get; set;}
        public DateTime FinalVigencia { get; set;}
    }
}
