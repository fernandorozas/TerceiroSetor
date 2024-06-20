using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.OrganizacoesSociais;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class ConselhoCommand : CommandBase
    {
        [Display(Name ="Organização Social")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public Guid OrganizacaoSocialId { get; set; }

        [Display(Name = "Tipo de Conselho")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public int TipoConselho { get; set; }

        [Display(Name = "Data Inicial de Vigência")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public DateTime InicioVigencia { get; set; }

        [Display(Name = "Data Final de Vigência")]
        public DateTime FinalVigencia { get; set; }
        public ICollection<ConselhoMembroDTO> Membros { get; set; }
    }
}
