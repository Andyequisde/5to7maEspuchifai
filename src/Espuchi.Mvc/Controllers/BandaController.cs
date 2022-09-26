using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;

namespace Espuchi.Mvc.Controllers
{
    public class BandaController : Controller
    {
        private readonly IAdo Ado ;

        public BandaController(IAdo ado) => Ado = ado;

        public IActionResult Index()
        {
            var bandas = Ado.ObtenerBanda();
            return View("Listado", bandas);
        }

        public IActionResult AltaBanda()
        {
            return View();
        }
    }
}