using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;
using Espuchi.Core.Mvc.ViewModels;

namespace Espuchi.Mvc.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAdo Ado;

        public AlbumController(IAdo ado) => Ado = ado;

        public IActionResult Index(ushort IdBanda)
        {
            var album = Ado.FiltrarAlbum(IdBanda);
            return View("listas", album);

        }

        [HttpGet]
        public IActionResult AltaAlbum()
        {
            var bandas = Ado.ObtenerBanda();
            var vmAlbum = new VMAlbum(bandas);
            return View("Upsert", vmAlbum);
        }

        [HttpPost]
        public IActionResult Upsert(VMAlbum vmAlbum)
        {
            if (!ModelState.IsValid)
                return View("Upsert", vmAlbum);

            if (vmAlbum.IdAlbum == 0)
            {
                var banda = Ado.BandaPorId(vmAlbum.IdBanda);
                var album = new Album(vmAlbum.NombreAlbum!, vmAlbum.Lanzamiento, vmAlbum.CantRepro, banda);
                album.Canciones = new List<Cancion>();
                Ado.AltaAlbum(album);
            }
            return RedirectToAction("Index");
        }
        //<a asp-controller="Album" asp-action="Index" asp-route-id="@banda.IdBanda">@banda.Nombre</a>
    }
}