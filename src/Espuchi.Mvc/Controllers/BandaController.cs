using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;

namespace Espuchi.Mvc.Controllers
{
    public class BandaController : Controller
    {
        private readonly IAdo Ado;

        public BandaController(IAdo ado) => Ado = ado;

        public async Task<IActionResult> Index()
        {
            var bandas = await Ado.ObtenerBanda();
            return View("Listado", bandas);
        }

        [HttpGet]
        public IActionResult AltaBanda()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AltaBanda(Banda banda)
        {
            await Ado.AltaBanda(banda);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalle(ushort IdBanda)
        {
            var bandas = await Ado.BandaPorId(IdBanda);
            bandas.Albunes = await Ado.FiltrarAlbum(IdBanda);
            return View("Detalle", bandas);
        }

        [HttpGet]
        public async Task<IActionResult> ModificarBanda(ushort IdBanda)
        {
            var banda = await Ado.BandaPorId(IdBanda);
            if (banda is null)
            {
                return NotFound();
            }
            return View("ModificarBanda", banda);
        }
        [HttpPost]
        public async Task<IActionResult> ModificarBanda(Banda banda)
        {
            await Ado.ActualizarBanda(banda);
            return Redirect(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> EliminarBanda(ushort IdBanda)
        {
            var banda = await Ado.BandaPorId(IdBanda);
            if (banda is null)
            {
                return NotFound();
            }
            return View(banda);
        }
        [HttpPost]
        public async Task<IActionResult> EliminarBanda(Banda banda)
        {
            await Ado.EliminarBanda(banda);
            return Redirect(nameof(Index));
        }
    }
}