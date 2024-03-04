﻿using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzione_EmailController : ControllerBase
    {
        private readonly IListaDistribuzione_DestinatarioService _listaDistribuzione_DestinatarioService;
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        public ListaDistribuzione_EmailController(IListaDistribuzione_DestinatarioService listaDistribuzione_DestinatarioService, 
            IListaDistribuzioneService listaDistribuzioneService)
        {
            _listaDistribuzione_DestinatarioService = listaDistribuzione_DestinatarioService;
            _listaDistribuzioneService = listaDistribuzioneService;
        }

        [HttpPost]
        [Route("addDestinatario")]
        public async Task<IActionResult> AddListaDistribuzione_DestinatarioAsync(AddListaDistribuzione_DestinatarioRequest request)
        {
            var IdProprietario = await _listaDistribuzioneService.GetProprietarioListaAsync(request.idLista);
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            if (IdUtente.Equals(IdProprietario))
            {
                var risultatoAggiunta = await _listaDistribuzione_DestinatarioService.AddListaDistribuzione_DestinatarioAsync(request.idLista,request.email);
                if (risultatoAggiunta == null)
                {
                    return BadRequest(ResponseFactory.WithError("Tentativo di aggiunta di un destinatario ad una lista in cui è già presente"));
                }
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Tentativo di aggiunta di un destinatario in una lista di cui non si è proprietari o che non esiste"));
            }
            return Ok(ResponseFactory.WithSuccess("Destinatario aggiunto con successo"));
        }

        [HttpDelete]
        [Route("deleteDestinatario")]
        public async Task<IActionResult> DeleteListaDistribuzione_DestinatarioAsync(DeleteListaDistribuzione_DestinatarioRequest request)
        {
            var IdProprietario = await _listaDistribuzioneService.GetProprietarioListaAsync(request.idLista);
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            if (IdUtente.Equals(IdProprietario))
            {
                var listaDistribuzione_DestinatarioDeleted = await _listaDistribuzione_DestinatarioService.
                    DeleteListaDistribuzione_DestinatarioAsync(request.idLista, request.email);
                if(listaDistribuzione_DestinatarioDeleted == null)
                {
                    return BadRequest(ResponseFactory.WithError("I parametri forniti non hanno fornito nessun risultato"));
                }
            }
            else
            {
                return BadRequest(ResponseFactory.WithError("Tentativo di eliminazione di una email da una lista di cui non si è proprietari o che non esiste"));
            }
            return Ok(ResponseFactory.WithSuccess("Destinatario rimosso con successo"));
        }

    }
}
