using TerceiroSetor.Application.Gateways;
using TerceiroSetor.Domain.Entities;

namespace TerceiroSetor.Emails
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmail(IdentityUser user, TipoEmail tipoEmail)
        {
            throw new NotImplementedException();
        }
    }
}
