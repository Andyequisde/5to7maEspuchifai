using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Espuchi.Core;
using Microsoft.Extensions.Logging;

namespace Espuchi.Mvc.Controllers
{
    public class BandaController : Controller
    {
        private readonly IAdo Ado ;

        public BandaController(IAdo ado)
        {
            Ado = ado;
        }

        public IActionResult Index()
        {
            var bandas = Ado.ObtenerBanda();
            return View(bandas);
        }

    }
}