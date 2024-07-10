using MediatR;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;
using System;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class AlterarStatusOrganizacaoSocialCommandHandler : IRequestHandler<AlterarStatusOrganizacaoSocialCommand>
    {
        private readonly IRepositoryOrganizacaoSocial _repository;
        private readonly INotificator _notificator;

        public AlterarStatusOrganizacaoSocialCommandHandler(IRepositoryOrganizacaoSocial repository, INotificator notificator)
        {
            _repository = repository;
            _notificator = notificator;
        }

        public async Task Handle(AlterarStatusOrganizacaoSocialCommand request, CancellationToken cancellationToken)
        {

            var organizacaoSocial = await _repository.GetByIdAsync(request.OrganizacaoSocialId);
            if (organizacaoSocial == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

             if (request.DataAlteracao == DateTime.MinValue)
            {
                _notificator.AddNotification("Data de Desativação precisa ser preenchida");
                return;
            }

            organizacaoSocial.AlterarStatus(request.Ativo, request.DataAlteracao);

            await _repository.UpdateAsync(organizacaoSocial);
        }

    }
}