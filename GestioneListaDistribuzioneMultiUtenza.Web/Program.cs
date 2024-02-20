
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

            // Add services to the container.
            builder.Services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });
            builder.Services.AddScoped<IUtenteService,UtenteService>();
            builder.Services.AddScoped<UtenteRepository>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer("data source=localhost;Initial catalog=DistribuzioneMultiUtenza;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True;Trusted_Connection=true");
            });

            builder.Services.AddScoped<IEmailDestinatarioService, EmailDestinatarioService>();
            builder.Services.AddScoped<EmailDestinatarioRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
