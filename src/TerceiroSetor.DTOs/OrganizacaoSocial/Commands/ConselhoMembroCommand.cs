using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.Shared;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class ConselhoMembroCommand
    {
        public PessoaDTO Pessoa { get; set; }

        [Display(Name = "Início de Vigência")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public DateTime InicioVigencia { get; set; }

        [Display(Name = "Final de Vigência")]
        public DateTime FinalVigencia { get; set; }
    }
}
