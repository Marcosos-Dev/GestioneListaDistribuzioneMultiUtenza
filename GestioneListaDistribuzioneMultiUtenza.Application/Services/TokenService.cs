using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        private readonly IUtenteService _utenteService;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, IUtenteService utenteService)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _utenteService = utenteService;
        }
        public async Task<string> CreateTokenAsync(string email, string password)
        {
            var utente = await _utenteService.GetUtenteByEmailPasswordAsync(email, password);
            
            if(utente != null)
            {
                List<Claim> claims=new List<Claim>();
                claims.Add(new Claim("IdUtente", $"{utente.IdUtente}"));
                claims.Add(new Claim("Email", utente.Email));

                var securityKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
               );
                var credentials = new SigningCredentials(securityKey
                    , SecurityAlgorithms.HmacSha256);

                var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                    , null
                    , claims
                    , expires: DateTime.Now.AddMinutes(30)
                    , signingCredentials: credentials
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                return token;
            }
            return null;
            
        }
    }
}
