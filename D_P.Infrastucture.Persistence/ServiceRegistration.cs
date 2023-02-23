using D_P.Core.Application.Interfaces.Repository;
using D_P.Infrastucture.Persistence.Contexts;   
using D_P.Infrastucture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Infrastucture.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {

                var ConnectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(ConnectionString,
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            }
            #endregion

            #region Repositories
            //Configuracion de la inyeccion de dependencias
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICitaRepository, CitaRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IPruebaLaboratorioRepository, PruebaLaboratorioRepository>();
            services.AddTransient<IResultadosLRepository, ResultadosLRepository>();
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();
            #endregion
        }
    }
}
