using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Dapper.Helper
{
    public static class DapperHelperExtensions
    {
        public static IServiceCollection AddDapperHelper<TConnection>(this IServiceCollection services,
            IConfiguration config) where TConnection : IDbConnection, new()
        {
            services.AddOptions<DapperHelperOptions>()
                .Configure(config.Bind)
                .ValidateDataAnnotations();

            services.AddSingleton<IDapperHelper, DapperHelper<TConnection>>();
            return services;
        }
    }
}
