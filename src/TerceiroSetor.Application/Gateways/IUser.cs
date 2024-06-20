using System.Security.Claims;

namespace TerceiroSetor.Application.Gateways
{
    public interface IUser
    {
        string ObterNome();
        bool EstaAutenticado();
        string ObterAvatar();
        string ObterEmail();
        Guid ObterId();
        bool PossuiRole(string role);
        string ObterPerfil();
        ClaimsPrincipal ObterUsuario();

    }
}
