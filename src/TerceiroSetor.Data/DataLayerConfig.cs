using Microsoft.EntityFrameworkCore;
using TerceiroSetor.Application.Gateways.Repositories;
using TerceiroSetor.Data.Repositories;

namespace TerceiroSetor.Data
{
    public static class DataLayerConfig
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider =>
            {
                var httpContext = provider.GetService<IHttpContextAccessor>().HttpContext;
                var optionsBuilder = new DbContextOptionsBuilder<TerceiroSetorDbContext>();
                var tenant = httpContext.Request.Headers["X-Tenant"];

                if (string.IsNullOrEmpty(tenant))
                    tenant = "demonstracao";

                var connectionString = configuration.GetConnectionString("CosmosConnection");
                optionsBuilder.UseCosmos(connectionString, "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", tenant);

                return new TerceiroSetorDbContext(optionsBuilder.Options);
            });

            services.AddScoped<IRepositoryOrganizacaoSocial, RepositoryOrganizacaoSocial>();

            return services;
        }

    }
}
