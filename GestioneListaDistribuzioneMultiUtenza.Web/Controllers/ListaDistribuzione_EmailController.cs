using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListaDistribuzione_EmailController : ControllerBase
    {
        private readonly IListaDistribuzione_EmailService _listaDistribuzione_EmailService;
        public ListaDistribuzione_EmailController(IListaDistribuzione_EmailService emailDestinatarioService)
        {
            _listaDistribuzione_EmailService = emailDestinatarioService;
        }

        [HttpPost]
        [Route("addDestinatario")]
        public async Task<IActionResult> AggiungiDestinatarioAsync(AddDestinatarioToListRequest request)
        {
            await _listaDistribuzione_EmailService.AddDestinatarioToListAsync(request);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public IActionResult DeleteDestinatarioFromList(DeleteListaDistribuzione_EmailRequest request)
        {
            var item = request.ToEntity();
            _listaDistribuzione_EmailService.DeleteDestinatarioFromList(item);
            return Ok();
        }

        [HttpPost]
        [Route("getLists")]
        public IActionResult GetListaDistribuzioneFromEmail(GetListaFromEmailRequest request)
        {
            //TODO PAGINAZIONE
            var listeDiDistribuzione = _listaDistribuzione_EmailService.GetListaDistribuzioneFromEmail(request);

            var response = new GetListeFromEmailResponse();
            response.Liste = listeDiDistribuzione.Select(s =>
            new Application.Models.Dtos.ListaDistribuzioneDto(s)).ToList();

            return Ok(ResponseFactory
              .WithSuccess(response)
              );
        }

        [HttpPost]
        [Route("sendEmail")]
        public IActionResult SendEmailToList(DeleteListaDistribuzione_EmailRequest request)
        {
            return BadRequest();
        }
    }
}
