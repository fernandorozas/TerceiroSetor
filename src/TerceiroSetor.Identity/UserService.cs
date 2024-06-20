using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TerceiroSetor.Application.Gateways;

namespace TerceiroSetor.Identity
{
    public class UserService : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public UserService(IHttpContextAccessor accessor) => _accessor = accessor;
        public string ObterNome() => EstaAutenticado() ? _accessor?.HttpContext?.User.GetUsername() ?? "" : "";
        public Guid ObterId() => EstaAutenticado() ? Guid.Parse(_accessor?.HttpContext?.User?.GetUserId() ?? "") : Guid.Empty;
        public string ObterEmail() => EstaAutenticado() ? _accessor?.HttpContext?.User.GetUserEmail() ?? "" : "";
        public string ObterAvatar() => EstaAutenticado() ? _accessor?.HttpContext?.User.GetUserPicture() ?? "" : "";
        public bool EstaAutenticado() => _accessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        public bool PossuiRole(string role) => _accessor?.HttpContext?.User.IsInRole(role) ?? false;
        public ClaimsPrincipal ObterUsuario() => _accessor?.HttpContext?.User ?? new ClaimsPrincipal(new ClaimsIdentity());
        public string ObterPerfil() => EstaAutenticado() ? _accessor?.HttpContext?.User.GetRole() ?? "" : "";

    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value ?? "";
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("email");
            return claim?.Value ?? "";
        }

        public static string GetUserPicture(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("picture");
            return claim?.Value ?? "";
        }

        public static string GetUsername(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("name");
            return claim?.Value ?? "";
        }

        public static string GetRefreshToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("refreshToken");
            return claim?.Value ?? "";
        }

        public static string GetRole(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst(ClaimTypes.Role);
            return claim?.Value ?? "";
        }
    }
}
