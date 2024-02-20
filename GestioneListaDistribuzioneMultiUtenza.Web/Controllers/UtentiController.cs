using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    public class UtentiController : Controller
    {
        public async Task<IActionResult> CreateUtente(CreateUtenteRequest request)
        {
            return View();
        }
    }
}
