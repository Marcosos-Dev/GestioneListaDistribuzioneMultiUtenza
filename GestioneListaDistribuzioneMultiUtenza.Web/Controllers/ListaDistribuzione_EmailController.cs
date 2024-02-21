using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ListaDistribuzione_EmailController :ControllerBase
    {
        private readonly IListaDistribuzione_Email listaDistribuzione_EmailService;
        public ListaDistribuzione_EmailController(IListaDistribuzione_Email emailDestinatarioService)
        {
            listaDistribuzione_EmailService = emailDestinatarioService;
        }

        [HttpPost]
        [Route("addDestinatario")]
        public IActionResult aggiungeDestinatario(CreateListaDistribuzione_EmailRequest request)
        {
            listaDistribuzione_EmailService.addDestinatarioToList(request.listId, request.emailId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public IActionResult deleteDestinatarioFromList(CreateListaDistribuzione_EmailRequest request)
        {
            listaDistribuzione_EmailService.deleteDestinatarioFromList(request.listId, request.emailId);
            return Ok();
        }

        [HttpGet]
        [Route("getLists")]
        public IActionResult GetListaDistribuzionesOfEmail(CreateListaDistribuzione_EmailRequest request)
        {
            listaDistribuzione_EmailService.GetListaDistribuzionesOfEmail(request.emailId);
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
