using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestioneListaDistribuzioneMultiUtenza.Models.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<UtenteRepository>();
            services.AddScoped<ListaDistribuzione_DestinatarioRepository>();
            services.AddScoped<ListaDistribuzioneRepository>();
            services.AddScoped<DestinatarioRepository>();

            return services;
        }
    }
}
