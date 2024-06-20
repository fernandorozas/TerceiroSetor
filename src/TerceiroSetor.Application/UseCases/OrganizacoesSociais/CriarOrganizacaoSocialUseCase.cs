using AutoMapper;
using MediatR;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class CriarOrganizacaoSocialUseCase : IRequestHandler<OrganizacaoSocialCommand>
    {
        private readonly INotificator _notificator;
        private readonly IMapper _mapper;
        private readonly IRepositoryOrganizacaoSocial _repositoryOrganizacaoSocial;

        public CriarOrganizacaoSocialUseCase(INotificator notificator, IMapper mapper, 
            IRepositoryOrganizacaoSocial repositoryOrganizacaoSocial)
        {
            _notificator = notificator;
            _mapper = mapper;
            _repositoryOrganizacaoSocial = repositoryOrganizacaoSocial;
        }

        public async Task Handle(OrganizacaoSocialCommand viewModel, CancellationToken cancellationToken)
        {
            var organizacaoSocialCadastrada = await _repositoryOrganizacaoSocial.SearchAsync(x => x.Cnpj.Equals(viewModel.Identificacao.Cnpj));
            if (organizacaoSocialCadastrada.Any())
            {
                _notificator.AddNotification($"A entidade {organizacaoSocialCadastrada.First().Nome} já esta cadastrada com este CNPJ.");
                return;
            }

            var organizacaoSocial = _mapper.Map<OrganizacaoSocial>(viewModel);
            if (!organizacaoSocial.IsValid())
            {
                _notificator.AddNotifications(organizacaoSocial.ValidationResult);
            }

            await _repositoryOrganizacaoSocial.AddAsync(organizacaoSocial);
        }
    }
}
