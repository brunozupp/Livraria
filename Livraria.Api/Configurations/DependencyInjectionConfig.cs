using Livraria.Domain.Handlers;
using Livraria.Domain.Interfaces.Respositories;
using Livraria.Infra.Data.DataContexts;
using Livraria.Infra.Data.Respositories;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            #region DataContexts

            services.AddScoped<DataContext>();

            #endregion DataContexts

            #region Respositories

            services.AddTransient<ILivroRepository, LivroRepository>();

            #endregion Respositories

            #region Handlers

            services.AddTransient<LivroHandler, LivroHandler>();

            #endregion Handlers

            return services;
        }
    }
}
