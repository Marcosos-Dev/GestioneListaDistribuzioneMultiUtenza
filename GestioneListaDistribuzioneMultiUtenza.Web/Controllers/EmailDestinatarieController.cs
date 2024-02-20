using Microsoft.AspNetCore.Mvc;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    public class EmailDestinatarieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
