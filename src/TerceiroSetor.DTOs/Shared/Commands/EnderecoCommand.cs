using System.ComponentModel.DataAnnotations;

namespace TerceiroSetor.DTOs.Shared.Commands
{
    public class EnderecoCommand
    {

        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        [StringLength(8, ErrorMessage = AnnotationMessages.STRINGLENGTH, MinimumLength = 8)]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        [StringLength(100, ErrorMessage = AnnotationMessages.STRINGLENGTH, MinimumLength = 2)]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        [StringLength(20, ErrorMessage = AnnotationMessages.STRINGLENGTH, MinimumLength = 1)]
        public string Numero { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = AnnotationMessages.MAXLENGTH)]
        public string Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        [StringLength(100, ErrorMessage = AnnotationMessages.STRINGLENGTH, MinimumLength = 2)]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        [StringLength(30, ErrorMessage = AnnotationMessages.STRINGLENGTH, MinimumLength = 3)]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        [StringLength(2, ErrorMessage = AnnotationMessages.STRINGLENGTH, MinimumLength = 2)]
        public string Estado { get; set; } = string.Empty;
    }

}
