using TerceiroSetor.Domain.Entities;

namespace TerceiroSetor.Application.Gateways
{
    public interface IEmailSender
    {
        Task SendEmail(IdentityUser user, TipoEmail tipoEmail);

    }

    public enum TipoEmail
    {
        BoasVindas,

    }
}
