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
            bandas.Albunes = Ado.FiltrarAlbum(IdBanda);
            return View("Detalle", bandas);
        }

        [HttpGet]
        public IActionResult ModificarBanda(ushort IdBanda)
        {
            var banda = Ado.BandaPorId(IdBanda);
            if (banda is null)
            {
                return NotFound();
            }
            return View("ModificarBanda", banda);
        }
        [HttpPost]
        public IActionResult ModificarBanda(Banda banda)
        {
            Ado.ActualizarBanda(banda);
            return Redirect(nameof(Index));
        }
        [HttpGet]
        public IActionResult EliminarBanda(ushort IdBanda)
        {
            var banda = Ado.BandaPorId(IdBanda);
            if (banda is null)
            {
                return NotFound();
            }
            return View(banda);
        }
        [HttpPost]
        public IActionResult EliminarBanda(Banda banda)
        {
            Ado.EliminarBanda(banda);
            return Redirect(nameof(Index));
        }
    }
}