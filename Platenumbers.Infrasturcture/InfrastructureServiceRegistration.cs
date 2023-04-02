using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Platenumbers.Infrastructure.Logging;
using System.Runtime.CompilerServices;

namespace Platenumbers.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices (this IServiceCollection services, 
            IConfiguration configuration )
        {
            services.AddScoped(typeof(ILogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}