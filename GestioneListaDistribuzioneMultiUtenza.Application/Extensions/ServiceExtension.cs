using FluentValidation;
using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Services;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
                        AppDomain.CurrentDomain.GetAssemblies().
                        SingleOrDefault(assembly => assembly.GetName().Name == "GestioneListaDistribuzioneMultiUtenza.Application"));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<IListaDistribuzione_DestinatarioService, ListaDistribuzione_DestinatarioService>();
            services.AddScoped<IListaDistribuzioneService, ListaDistribuzioneService>();
            services.AddScoped<IDestinatarioService, DestinatarioService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();

            return services;
        }
    }
}
