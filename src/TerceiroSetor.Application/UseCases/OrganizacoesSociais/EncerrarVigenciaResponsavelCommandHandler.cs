using MediatR;

using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class EncerrarVigenciaResponsavelCommandHandler : IRequestHandler<EncerrarVigenciaResponsavelCommand>
    {
        private readonly IRepositoryOrganizacaoSocial _repository;
        private readonly INotificator _notificator;


        public EncerrarVigenciaResponsavelCommandHandler(IRepositoryOrganizacaoSocial repository, INotificator notificator)
        {
            _repository = repository;
            _notificator = notificator;
        }

        public async Task Handle(EncerrarVigenciaResponsavelCommand request, CancellationToken cancellationToken)
        {

            var organizacaoSocial = await _repository.GetByIdAsync(request.OrganizacaoSocialId);
            if (organizacaoSocial == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

            var responsavel = organizacaoSocial.Responsaveis.Where(x => (int)x.VinculoTrabalhista == (int)request.VinculoTrabalhista).FirstOrDefault();
            if (responsavel == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

            if (responsavel.InicioVigencia >= request.DataEncerramento)
            {
                _notificator.AddNotification("Data de Encerramento deve ser maior que data de início de vigência.");
                return;
            }

            organizacaoSocial.Responsaveis.Where(x => (int)x.VinculoTrabalhista == (int)request.VinculoTrabalhista).FirstOrDefault().EncerrarVigencia(request.DataEncerramento);

            await _repository.UpdateAsync(organizacaoSocial);
        }
    }
}
