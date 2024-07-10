using MediatR;
using System.ComponentModel.DataAnnotations;
using TerceiroSetor.DTOs.OrganizacoesSociais;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class AlterarEnderecoOrganizacaoSocialCommand : IRequest
    {
        public Guid OrganizacaoSocialId { get; set; }

        [Display(Name = "Cep")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string Cep { get;  set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string Logradouro { get; set; }

        [Display(Name = "Numero")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string NumeroImovel { get; set; }
        
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = AnnotationMessages.REQUIRED)]
        public string Estado { get; set; }

    }
}

