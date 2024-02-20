using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmailDestinatarioController : ControllerBase
    {
        private readonly IEmailDestinatarioService _emailDestinatarioService;
        public EmailDestinatarioController(IEmailDestinatarioService emailDestinatarioService)
        {
            _emailDestinatarioService = emailDestinatarioService;
        }

        /*[HttpPost]
        [Route("add")]
        public IActionResult addDestinatarioToListAsync([FromBody] EmailDestinatario email, int listId)
        {
            _emailDestinatarioService.addDestinatarioToListAsync(email, listId);
            return Ok();
        }*/

        [HttpPost]
        [Route("delete")]
        public IActionResult deleteDestinatarioFromList(CreateEmailDestinatarioRequest request)
        {
            var email = request.ToEntity();
            _emailDestinatarioService.deleteDestinatarioFromList(email);
            return Ok();
        }

        //TODO INSERIRE PAGINAZIONE
        [HttpGet]
        [Route("get")]
        public IActionResult GetListaDistribuzionesOfEmail(string email)
        {
            var res = _emailDestinatarioService.GetListaDistribuzionesOfEmail(email);
            return Ok();
        }

    }
}
