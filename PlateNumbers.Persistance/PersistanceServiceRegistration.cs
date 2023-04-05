using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platenumbers.Application.Contracts.Persistance;
using Platenumbers.Persistance.Repositories;
using Platenumbers.Persistance.UoW;
using PlateNumbers.Persistance.Repositories;
using PlateNumbers.Persistence.DatabaseContext;
using PlateNumbers.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlateNumbers.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PlateNumberContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("PlateNumbersConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPlateNumberRepository, PlateNumberRepository>();
            services.AddScoped<IReserveNumberRepository, ReserveNumberRepository>();
            services.AddScoped<IOrderNumberRepository, OrderNumberRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}