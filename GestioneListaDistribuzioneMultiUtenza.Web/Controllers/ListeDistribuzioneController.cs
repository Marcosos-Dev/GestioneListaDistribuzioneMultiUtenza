using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    public class ListeDistribuzioneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
