using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.Attributes;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class ResponsavelCommand : CommandBase
    {
        [Display(Name = "Organização Social")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public Guid OrganizacaoSocialId { get; set; }
        
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string NomeCompleto { get; set; }

        [Cpf]
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = AnnotationMessages.EMAIL)]
        [Display(Name = "E-mail Pessoal")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string EmailPessoal { get; set; }

        [EmailAddress(ErrorMessage = AnnotationMessages.EMAIL)]
        [Display(Name = "E-mail Institucional")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string EmailInstitucional { get; set; }

        [Display(Name = "Vínculo Trabalhista")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public int VinculoTrabalhista { get; set; }
        
        [Display(Name = "Início de Vigência")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public DateTime InicioVigencia { get; set; }

        [Display(Name = "Final de Vigência")]
        public DateTime FinalVigencia { get; set; }
    }
}
