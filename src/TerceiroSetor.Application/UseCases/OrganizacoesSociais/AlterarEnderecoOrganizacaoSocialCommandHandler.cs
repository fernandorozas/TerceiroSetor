using MediatR;
using TerceiroSetor.Application.Gateways;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.DTOs.OrganizacaoSocial.Commands;

namespace TerceiroSetor.Application.UseCases.OrganizacoesSociais
{
    public class AlterarEnderecoOrganizacaoSocialCommandHandler : IRequestHandler<AlterarEnderecoOrganizacaoSocialCommand>
    {
        private readonly IRepositoryOrganizacaoSocial _repository;
        private readonly INotificator _notificator;


        public AlterarEnderecoOrganizacaoSocialCommandHandler(IRepositoryOrganizacaoSocial repository, INotificator notificator)
        {
            _repository = repository;
            _notificator = notificator;
        }

        public async Task Handle(AlterarEnderecoOrganizacaoSocialCommand request, CancellationToken cancellationToken)
        {

            var organizacaoSocial = await _repository.GetByIdAsync(request.OrganizacaoSocialId);
            if (organizacaoSocial == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

            var endereco = organizacaoSocial.Endereco;
            if (endereco == null)
            {
                _notificator.AddNotification("NotFound");
                return;
            }

            organizacaoSocial.Endereco.AlterarEndereco ( request.Cep, 
                                                         request.Logradouro,
                                                         request.NumeroImovel,
                                                         request.Complemento,
                                                         request.Bairro,
                                                         request.Cidade,
                                                         request.Estado);

            await _repository.UpdateAsync(organizacaoSocial);
        }
    }

}


    
   



