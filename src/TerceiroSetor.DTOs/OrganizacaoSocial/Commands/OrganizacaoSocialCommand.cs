using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.Attributes;
using TerceiroSetor.DTOs.Shared.Commands;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class OrganizacaoSocialCommand : CommandBase
    {
        public OrganizacaoSocialIdentificacaoCommand Identificacao { get; set; } = new OrganizacaoSocialIdentificacaoCommand();
        public EnderecoCommand Endereco { get; set; } = new EnderecoCommand();
    }

    public class OrganizacaoSocialIdentificacaoCommand
    {
        [Display(Name = "Nome da Organização Social")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string Nome { get; set; }

        [Display(Name = "Tipo da Organização Social")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public int TipoOrganizacaoSocial { get; set; }

        [Display(Name = "Data de Constituição")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public DateTime DataConstituicao { get; set; }

        public string Telefone { get; set; }

        [Cnpj]
        public string Cnpj { get; set; }

        [Display(Name = "Artigo de Referência")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string ArtigoReferencia { get; set; }

        [Display(Name = "Finalidade")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public int Finalidade { get; set; }

        [Display(Name = "Finalidade Resumida")]
        public string FinalidadeResumida { get; set; }
    }
}
