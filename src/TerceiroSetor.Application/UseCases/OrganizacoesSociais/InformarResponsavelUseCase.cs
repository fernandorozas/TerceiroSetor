using AutoMapper;
using MediatR;
using TerceiroSetor.Application.Events.UsuarioAdicionado;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Domain.Entities.OrganizacoesSociais;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class InformarResponsavelUseCase : IRequestHandler<ResponsavelCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly INotificator _notificator;
        private readonly IRepositoryOrganizacaoSocial _repositoryOrganizacaoSocial;
        public InformarResponsavelUseCase(IMapper mapper, IMediator mediator, INotificator notificator,
            IRepositoryOrganizacaoSocial repositoryOrganizacaoSocial)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notificator = notificator;
            _repositoryOrganizacaoSocial = repositoryOrganizacaoSocial;
        }

        public async Task Handle(ResponsavelCommand viewModel, CancellationToken cancellationToken)
        {
            var novoResponsavel = _mapper.Map<Responsavel>(viewModel);
            var organizacaoSocial = await _repositoryOrganizacaoSocial.GetByIdAsync(viewModel.OrganizacaoSocialId);

            if (organizacaoSocial.Responsaveis.Any(x => x.Cpf == novoResponsavel.Cpf))
            {
                _notificator.AddNotification("Já existe um responsável com este Cpf informado.");
                return;
            }

            organizacaoSocial.InformarResponsavel(novoResponsavel);
            await _repositoryOrganizacaoSocial.UpdateAsync(organizacaoSocial);

            var eventoUsuarioAdicionado = new UsuarioAdicionadoEvent(organizacaoSocial.Id, novoResponsavel.Cpf,
                novoResponsavel.EmailInstitucional, novoResponsavel.NomeCompleto, TipoUsuario.ResponsavelOrganizacaoSocial);

            //await _mediator.Publish(eventoUsuarioAdicionado);
        }
    }
}
