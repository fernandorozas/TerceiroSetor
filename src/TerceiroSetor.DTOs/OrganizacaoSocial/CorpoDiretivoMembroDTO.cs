using TerceiroSetor.DTOs.Shared;

namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public class CorpoDiretivoMembroDTO 
    {
        public CorpoDiretivoDTO CorpoDiretivo { get; set;}
        public PessoaDTO Pessoa { get; set;}
        public DateTime InicioVigencia { get; set;}
        public DateTime FinalVigencia { get; set;}
    }
}
