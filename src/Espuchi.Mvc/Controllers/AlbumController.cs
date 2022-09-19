using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;

namespace Espuchi.Mvc.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAdo Ado ;

        public AlbumController(IAdo ado) => Ado = ado;

        public IActionResult Index()
        {
            var albums = Ado.ObtenerAlbum();
            return View("Listado", albums);
        }
    }
}