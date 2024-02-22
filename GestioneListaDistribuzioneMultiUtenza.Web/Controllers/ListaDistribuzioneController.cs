using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzione _listaDistribuzioneService;
        private readonly IUtenteService _utenteService;
        public ListaDistribuzioneController(IListaDistribuzione listaDistribuzioneService, IUtenteService utenteService)
        {
            _listaDistribuzioneService = listaDistribuzioneService;
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("addNewList")]
        public async Task<IActionResult> AggiungiListaAsync(CreateListaDistribuzioneRequest request)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            int IdUtente = int.Parse(claimsIdentity.Claims
                .Where(c => c.Type == "IdUtente").First().Value);

            var lista = request.ToEntity();
            lista.IdProprietario = IdUtente;
            //lista.UtenteProprietario=await _utenteService.GetUtenteByIdAsync(IdUtente);
            await _listaDistribuzioneService.AggiungiListaAsync(lista);
            return Ok(lista);
        }

    }
}
