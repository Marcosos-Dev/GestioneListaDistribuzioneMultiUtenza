using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest request)
        {
            string token = await _tokenService.CreateTokenAsync(request.Email, request.Password);
            if(token != null)
            {
                return Ok(token);
            }
            return BadRequest(ResponseFactory.WithError("Email e/o Password errate"));
        }
    }
}
