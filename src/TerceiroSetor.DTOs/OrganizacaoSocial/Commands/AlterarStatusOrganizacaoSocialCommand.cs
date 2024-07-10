using MediatR;
using TerceiroSetor.DTOs.OrganizacoesSociais;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class AlterarStatusOrganizacaoSocialCommand : IRequest
    {
        public Guid OrganizacaoSocialId { get; set; }
        public Boolean Ativo { get; set; } 

        public DateTime DataAlteracao { get; set; } 

    }

}
