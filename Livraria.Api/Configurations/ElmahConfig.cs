using ElmahCore;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Livraria.Infra.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.Api.Configurations
{
    public static class ElmahConfig
    {
        public static IServiceCollection AddElmahCoreConfig(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddElmah();

            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.LogPath = "~/log";
            });

            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = appSettings.ConnectionString;
            });

            return services;
        }
    }
}
