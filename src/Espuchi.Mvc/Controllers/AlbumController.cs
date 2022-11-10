using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;

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
            return View();
        }
        
        [HttpPost]
        public IActionResult AltaAlbum(Album album)
        {
            Ado.AltaAlbum(album);
            return RedirectToAction(nameof(Index));
        }
        //<a asp-controller="Album" asp-action="Index" asp-route-id="@banda.IdBanda">@banda.Nombre</a>
    }
}