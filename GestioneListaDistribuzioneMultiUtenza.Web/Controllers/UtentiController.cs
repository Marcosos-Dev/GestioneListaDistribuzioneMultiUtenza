using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtentiController : ControllerBase
    {
        private readonly IUtenteService _utenteService;
        public UtentiController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreateUtente(CreateUtenteRequest request)
        {
            //jwt
            var utente = request.toEntity();
            await _utenteService.AddUtenteAsync(utente);
            //response
            return Ok();
        }
    }
}