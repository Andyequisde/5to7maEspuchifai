using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;

namespace Espuchi.Mvc.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAdo Ado;

        public AlbumController(IAdo ado) => Ado = ado;

        public IActionResult Index()
        {
            var album = Ado.ObtenerAlbum();
            return View("Listas", album);
        }
        //<a asp-controller="Album" asp-action="Index" asp-route-id="@banda.IdBanda">@banda.Nombre</a>
    }
}