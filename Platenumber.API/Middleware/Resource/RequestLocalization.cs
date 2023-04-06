using Microsoft.EntityFrameworkCore;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Persistance.Repositories;
using PlateNumbers.Persistance.Repositories;
using Platenumbers.Persistance.UoW;
using PlateNumbers.Persistence.DatabaseContext;
using PlateNumbers.Persistence.Repositories;

namespace Platenumbers.API.Middleware.Localization
{
    public static class RequestLocalization
    {
        public static IServiceCollection AddReqLoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalization(o => { o.ResourcesPath = "Resources"; });

            // set the default culture and supported culture list
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture("ge-GE");
                options.FallBackToParentUICultures = true;
                options.RequestCultureProviders.Clear();
            });

            return services;
        }
    }
}
