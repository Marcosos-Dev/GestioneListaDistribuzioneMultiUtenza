
using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Options;
using GestioneListaDistribuzioneMultiUtenza.Application.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Context;
using GestioneListaDistribuzioneMultiUtenza.Models.Repositories;
using GestioneListaDistribuzioneMultiUtenza.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GestioneListaDistribuzioneMultiUtenza.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer("data source=localhost;Initial catalog=DistribuzioneMultiUtenza;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True;Trusted_Connection=true");
            });

            // Add services to the container.
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUtenteService,UtenteService>();
            builder.Services.AddScoped<UtenteRepository>();
            builder.Services.AddScoped<IListaDistribuzione_DestinatarioService, ListaDistribuzione_DestinatarioService>();
            builder.Services.AddScoped<ListaDistribuzione_DestinatarioRepository>();
            builder.Services.AddScoped<IListaDistribuzioneService, ListaDistribuzioneService>();
            builder.Services.AddScoped<ListaDistribuzioneRepository>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<DestinatarioRepository>();
            builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

            builder.Services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Lista Distribuzione Multiutente Test",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
            }
        },
        new string[] {}
    }
});
            });

            var jwtAuthenticationOption = new JwtAuthenticationOption();
            configuration.GetSection("JwtAuthentication")
                .Bind(jwtAuthenticationOption);
            

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    string key = jwtAuthenticationOption.Key;
                    var securityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(key)
                        );
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtAuthenticationOption.Issuer,
                        IssuerSigningKey = securityKey
                    };
                });
            builder.Services.Configure<JwtAuthenticationOption>(
            configuration.GetSection("JwtAuthentication")
            );
            builder.Services.Configure<EmailOption>(
                configuration.GetSection("EmailOption")
                );

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<UserIdentityMiddleware>();

            app.Run();
        }
    }
}
