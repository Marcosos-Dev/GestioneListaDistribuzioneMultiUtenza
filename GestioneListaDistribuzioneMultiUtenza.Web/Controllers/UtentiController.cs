using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;
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
        [Route("createUtente")]
        public async Task<IActionResult> CreateUtenteAsync(CreateUtenteRequest request)
        {
            if(await _utenteService.GetUtenteByEmailAsync(request.Email) != null) 
            {
                return BadRequest(ResponseFactory.WithError("L'utente già esiste"));
            }
            var utente = request.toEntity();
            await _utenteService.CreateUtenteAsync(utente);
            //response
            var response = new CreateUtenteResponse();
            response.Utente = new Application.Models.Dtos.UtenteDto(utente);

            return Ok(ResponseFactory
              .WithSuccess(response)
              );
        }
    }
}