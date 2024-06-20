using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.Attributes;

namespace TerceiroSetor.DTOs.Shared.Commands
{
    public class PessoaCommand
    {
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
        
        public EnderecoCommand Endereco { get; set; }
    }
}
