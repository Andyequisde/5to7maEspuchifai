using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;

namespace Espuchi.Mvc.Controllers
{
    public class BandaController : Controller
    {
        private readonly IAdo Ado;

        public BandaController(IAdo ado) => Ado = ado;

        public IActionResult Index()
        {
            var bandas = Ado.ObtenerBanda();
            return View("Listado", bandas);
        }

        [HttpGet]
        public IActionResult AltaBanda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AltaBanda(Banda banda)
        {
            Ado.AltaBanda(banda);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalle(ushort IdBanda)
        {
            var bandas = Ado.BandaPorId(IdBanda);
            return View("Detalle", bandas);
        }
        
        public IActionResult ModificarBanda(Banda banda)
        {
            var bandas = Ado.ActualizarBanda(banda);
            return View(bandas);
        }
    }
}