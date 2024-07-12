using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{

    public class RemoveOrganizacaoSocialCommandHandler : IRequestHandler<RemoveOrganizacaoSocialCommand, bool>
    {
        private readonly IRepositoryOrganizacaoSocial _repository;
        private readonly INotificator _notificator;

        public RemoveOrganizacaoSocialCommandHandler(IRepositoryOrganizacaoSocial repository, INotificator notificator)
        {
            _repository = repository;
            _notificator = notificator;
        }

        public async Task<bool> Handle(RemoveOrganizacaoSocialCommand request, CancellationToken cancellationToken)
        {
            var organizacaoSocial = await _repository.GetByIdAsync(request.Id);

            if (organizacaoSocial == null)
            {
                _notificator.AddNotification("NotFound");
                return false;
            }

            await _repository.RemoveAsync(request.Id);
            return true;
        }
    }

}