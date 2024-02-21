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
        public IActionResult AggiungeDestinatario(CreateListaDistribuzione_EmailRequest request)
        {
            _listaDistribuzione_EmailService.AddDestinatarioToList(request.listId, request.emailId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public IActionResult DeleteDestinatarioFromList(CreateListaDistribuzione_EmailRequest request)
        {
            _listaDistribuzione_EmailService.DeleteDestinatarioFromList(request.listId, request.emailId);
            return Ok();
        }

        [HttpGet]
        [Route("getLists")]
        public IActionResult GetListaDistribuzionesOfEmail(CreateListaDistribuzione_EmailRequest request)
        {
            _listaDistribuzione_EmailService.GetListaDistribuzionesOfEmail(request.emailId);
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
