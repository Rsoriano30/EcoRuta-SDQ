using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Intefaces.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayerWebApp(this IServiceCollection services)
        {
            AddApplicationLayerGenericConfiguration(services);

            #region Services
            AddApplicationLayerGenericServices(services);

            services.AddTransient<IReportesService, ReportesService>();
            services.AddTransient<IRutasService, RutasService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            #endregion
        }

        #region private
        private static void AddApplicationLayerGenericConfiguration(this IServiceCollection services)
        {
            #region Configurations
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion
        }

        private static void AddApplicationLayerGenericServices(this IServiceCollection services)
        {
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            #endregion
        }
        #endregion
    }
}
