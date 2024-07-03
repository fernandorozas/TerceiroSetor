using TerceiroSetor.Domain.ValueObjects;
using TerceiroSetor.DTOs.Attributes;
using TerceiroSetor.DTOs.Shared;

namespace TerceiroSetor.DTOs.OrganizacoesSociais
{
    public class OrganizacaoSocialDTO : CommandBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set;}
        public TipoOrganizacaoSocialDTO TipoOrganizacaoSocial { get; set;}
        public DateTime DataConstituicao { get; set;}
        public EnderecoDTO Endereco { get; set;}
        public string Telefone { get; set;}
        [Cnpj]
        public string Cnpj { get; set;}
        public string ArtigoReferencia { get; set;}
        public string FinalidadeResumida { get; set;}
        public FinalidadeDTO Finalidade { get; set;}
        public CorpoDiretivoDTO CorpoDiretivo { get; set;}
        public ICollection<ConselhoDTO> Conselhos { get; set;}
        public ICollection<ResponsavelDTO> Responsaveis { get; set;}
        public ICollection<ContaBancariaDTO> Contas { get; set;}

    }
}
