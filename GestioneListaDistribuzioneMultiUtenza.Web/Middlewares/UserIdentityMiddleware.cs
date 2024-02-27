using System.Security.Claims;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Middlewares
{
    public class UserIdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public UserIdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var claimsIdentity = context.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var idUtenteClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "IdUtente");
                if (idUtenteClaim != null && int.TryParse(idUtenteClaim.Value, out int idUtente))
                {
                    context.Items["IdUtente"] = idUtente;
                }
            }

            await _next(context);
        }
    }
}
