using AutoMapper;
using MediatR;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class InformarConselhoUseCase : IRequestHandler<ConselhoCommand>
    {
        private readonly IMapper _mapper;
        private readonly INotificator _notificator;
        private readonly IRepositoryOrganizacaoSocial _repositoryOrganizacaoSocial;

        public InformarConselhoUseCase(IMapper mapper, IRepositoryOrganizacaoSocial repositoryOrganizacaoSocial,
            INotificator notificator)
        {
            _mapper = mapper;
            _repositoryOrganizacaoSocial = repositoryOrganizacaoSocial;
            _notificator = notificator;
        }

        public async Task Handle(ConselhoCommand viewModel, CancellationToken cancellationToken)
        {
            var novoConselho = _mapper.Map<Conselho>(viewModel);
            var validacoesConselho = new ValidatorConselhoValido().Validate(novoConselho);

            var organizacaoSocial = await _repositoryOrganizacaoSocial.GetByIdAsync(viewModel.OrganizacaoSocialId);
            if (!validacoesConselho.IsValid)
            {
                _notificator.AddNotifications(validacoesConselho);
                return;
            }

            if(organizacaoSocial.Conselhos.Any(x => x.TipoConselho == novoConselho.TipoConselho))
            {
                _notificator.AddNotification("Já existe um conselho deste tipo informado!");
                return;
            }
            
            organizacaoSocial.InformarConselho(novoConselho);
            await _repositoryOrganizacaoSocial.UpdateAsync(organizacaoSocial);
        }
    }
}
