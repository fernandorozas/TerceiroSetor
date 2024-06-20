using Microsoft.Extensions.DependencyInjection;
using TerceiroSetor.Application.Gateways;

namespace TerceiroSetor.Emails
{
    public static class EmailConfig
    {
        public static IServiceCollection AddEmail(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            return services;
        }
        
    }
}
