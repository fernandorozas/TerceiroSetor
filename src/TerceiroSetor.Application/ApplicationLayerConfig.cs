using System.Reflection;
using TerceiroSetor.Application.Notifications;
using TerceiroSetor.Application.Queries;

namespace TerceiroSetor.Application
{
    public static class ApplicationLayerConfig
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();
            services.AddAutoMapper(typeof(MapperConfig));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IQueriesOrganizacaoSocial, QueriesOrganizacaoSocial>();

            return services;
        }
    }
}
