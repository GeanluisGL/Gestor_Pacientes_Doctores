using D_P.Core.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using D_P.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using D_P.Infrastucture.Persistence.Repositories;
using D_P.Core.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application
{
    //Aqui se extiende la interfaz (Open-close extention)
    //No se modifica la clase pero extiende y acepta mas funcionalidades
    //Extentions method -- Decorator
    public static class ServiceRegistration
    {
        //Aqui se decora la clase que se quiere extender, por medio del IserviceCollection
        //y  configura la base de datos por medio del objeto tipo Iconfiguration
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<ICitasServices, CitasServices>();
            services.AddTransient<IMedicosServices, MedicoServices>();
            services.AddTransient<IPacientesServices, PacientesServices>();
            services.AddTransient<IpruebaLaboratorioServices, PruebaLaboratorioServices>();
            services.AddTransient<IResultadoLaboratorioServices, ResultadosLServices>();
            services.AddTransient<IUsuariosServices, UsuariosServices>();
            #endregion
        }   

    }
}
