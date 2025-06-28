using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Repositories;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Structure.Context;
using Structure.Repositories;

namespace Structure
{
    public static class ServiceExtension
    {
        public static void AddPersistenceInfraestructureLayer(this IServiceCollection services, IConfiguration config)
        {
            #region Database Connection
            
            services.AddDbContext<EcoRutaContext>(options => options.UseSqlServer(config.GetConnectionString("DbConnection"),
                m => m.MigrationsAssembly(typeof(EcoRutaContext).Assembly.FullName)));

            #endregion

            #region Repositories

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IReportesRepository, ReportesRepository>();
            #endregion

        }
    }
}
