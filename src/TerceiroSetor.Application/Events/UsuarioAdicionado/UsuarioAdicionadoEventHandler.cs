using MediatR;
using TerceiroSetor.Application.Gateways;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Domain.Entities;
using static TerceiroSetor.Domain.Entities.IdentityUser;

namespace TerceiroSetor.Application.Events.UsuarioAdicionado
{
    public class UsuarioAdicionadoEventHandler : INotificationHandler<UsuarioAdicionadoEvent>
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly IEmailSender _emailSender;
        private readonly IRepositoryOrganizacaoSocial _repositoryOrganizacaoSocial;

        public UsuarioAdicionadoEventHandler(IIdentityService identityService, IHttpContextAccessor httpContextAcessor, 
            IRepositoryOrganizacaoSocial repositoryOrganizacaoSocial, IEmailSender emailSender)
        {
            _identityService = identityService;
            _httpContextAcessor = httpContextAcessor;
            _emailSender = emailSender;
            _repositoryOrganizacaoSocial = repositoryOrganizacaoSocial;
        }

        private readonly UserGroup userGroup = new UserGroup() { Name = "TerceiroSetor"};
        public async Task Handle(UsuarioAdicionadoEvent evento, CancellationToken cancellationToken)
        {
            var tenant = _httpContextAcessor.HttpContext.Request.Headers["X-Tenant"];
            var usuarioExiste = await _identityService.GetUser(evento.Email);
            if (usuarioExiste != null) 
            {
                await _identityService.AddRole(usuarioExiste, evento.TipoUsuario.ToString());
                await _identityService.AddTenant(usuarioExiste, tenant);
                return;
            }

            var novoUsuario = new IdentityUser()
            {
                FirstName = evento.Nome,
                Email = evento.Email
            };

            novoUsuario.Groups.Add(userGroup);
            novoUsuario.Roles.Add(new UserRole() { Name = evento.TipoUsuario.ToString()});
            novoUsuario.Attributes.Tenant.Add(tenant);

            await _identityService.AddUser(novoUsuario);
            await _emailSender.SendEmail(novoUsuario, TipoEmail.BoasVindas);
            await _repositoryOrganizacaoSocial.AtualizarUsuarioResponsavel(evento.OrganizacaoSocialId, evento.Cpf, novoUsuario.Id);

        }
    }
}
