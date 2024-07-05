using MediatR;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class EncerrarVigenciaConselhoCommandHandler : IRequestHandler<EncerrarVigenciaConselhoCommand>
    {
        private readonly IRepositoryOrganizacaoSocial _repository;
        private readonly INotificator _notificator;

        public EncerrarVigenciaConselhoCommandHandler(IRepositoryOrganizacaoSocial repository, INotificator notificator)
        {
            _repository = repository;
            _notificator = notificator;
        }

        public async Task Handle(EncerrarVigenciaConselhoCommand request, CancellationToken cancellationToken)
        {
            
           var organizacaoSocial = await _repository.GetByIdAsync(request.OrganizacaoSocialId);
            if (organizacaoSocial == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

            var conselho = organizacaoSocial.Conselhos.Where(x => (int)x.TipoConselho == (int)request.TipoConselho).FirstOrDefault();
            if (conselho == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

            if (conselho.InicioVigencia >= request.DataEncerramento)
            {
                _notificator.AddNotification("Data de Encerramento deve ser maior que data de início de vigência.");
                return;
            }

            organizacaoSocial.Conselhos.Where(x => (int)x.TipoConselho == (int)request.TipoConselho).FirstOrDefault().EncerrarVigencia(request.DataEncerramento);

            await _repository.UpdateAsync(organizacaoSocial);
        }
    }
}
