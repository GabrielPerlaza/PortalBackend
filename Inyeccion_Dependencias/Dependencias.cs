using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Capa_Datos.DataBaseContext;
using Utilidades;
using Capa_Datos.Repositorio.Contrato;
using Capa_Negocio.Servicios.Contrato;
using Microsoft.Extensions.Configuration;
using Capa_Datos.Repositorio;
using Capa_Negocio.Servicios;
namespace Inyeccion_Dependencias
{
    public static class Dependencias
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            }
            );
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IArticuloService, ArticuloService>();

        }


    }
}
