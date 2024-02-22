using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListeDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzioneService listaDistribuzioneService;
        public ListeDistribuzioneController(IListaDistribuzioneService emailDestinatarioService)
        {
            listaDistribuzioneService = emailDestinatarioService;
        }

        [HttpPost]
        [Route("addNewList")]
        public async Task<IActionResult> AggiungiLista(CreateListaDistribuzioneRequest request)
        {
            var lista = request.ToEntity();
            await listaDistribuzioneService.AggiungiListaAsync(lista);
            return Ok();
        }

    }
}
