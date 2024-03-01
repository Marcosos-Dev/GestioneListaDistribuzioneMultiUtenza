using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;
using GestioneListaDistribuzioneMultiUtenza.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        public ListaDistribuzioneController(IListaDistribuzioneService listaDistribuzioneService)
        {
            _listaDistribuzioneService = listaDistribuzioneService;
        }

        [HttpPost]
        [Route("createListaDistribuzione")]
        public async Task<IActionResult> CreateListaDistribuzioneAsync(CreateListaDistribuzioneRequest request)
        {
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            var lista = request.ToEntity();
            lista.IdProprietario = IdUtente;
            await _listaDistribuzioneService.AddListaDistribuzioneAsync(lista);

            var response = new CreateListaDistribuzioneResponse();
            response.ListaDistribuzione = new Application.Models.Dtos.ListaDistribuzioneDto(lista);
            return Ok(ResponseFactory
          .WithSuccess(response)
          );
        }
    }
}
