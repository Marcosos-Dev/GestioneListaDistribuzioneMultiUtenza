using GestioneListaDistribuzioneMultiUtenza.Web.Middlewares;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
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

            return app;
        }
    }
}
