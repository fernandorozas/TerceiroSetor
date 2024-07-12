using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerceiroSetor.DTOs.OrganizacaoSocial.Commands
{
    public class RemoveOrganizacaoSocialCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public RemoveOrganizacaoSocialCommand(Guid id)
        {
            Id = id;
        }
    }
}
