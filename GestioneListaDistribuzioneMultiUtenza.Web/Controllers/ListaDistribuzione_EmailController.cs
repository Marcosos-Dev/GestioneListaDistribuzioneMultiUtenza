using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListaDistribuzione_EmailController :ControllerBase
    {
        private readonly IListaDistribuzione_Email _listaDistribuzione_EmailService;
        public ListaDistribuzione_EmailController(IListaDistribuzione_Email emailDestinatarioService)
        {
            _listaDistribuzione_EmailService = emailDestinatarioService;
        }

        [HttpPost]
        [Route("addDestinatario")]
        public async Task<IActionResult> AggiungiDestinatarioAsync(CreateListaDistribuzione_EmailRequest request)
        {
            var item = request.ToEntity();
            await _listaDistribuzione_EmailService.AddDestinatarioToListAsync(item);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public IActionResult DeleteDestinatarioFromList(CreateListaDistribuzione_EmailRequest request)
        {
            var item = request.ToEntity();
            _listaDistribuzione_EmailService.DeleteDestinatarioFromList(item);
            return Ok();
        }

        [HttpGet]
        [Route("getLists")]
        public IActionResult GetListaDistribuzioneOfEmail(CreateListaDistribuzione_EmailRequest request)
        {
            _listaDistribuzione_EmailService.GetListaDistribuzioneFromEmail(request.emailId);
            return Ok();
        }

        [HttpPost]
        [Route("sendEmail")]
        public IActionResult SendEmailToList(CreateListaDistribuzione_EmailRequest request)
        {
            return BadRequest();
        }
    }
}
