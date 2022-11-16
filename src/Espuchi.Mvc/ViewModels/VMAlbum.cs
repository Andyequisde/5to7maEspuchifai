using System.ComponentModel.DataAnnotations;
using Espuchi.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Espuchi.Core.Mvc.ViewModels
{
    public class VMAlbum
    {
        public SelectList? BandaList { get; set; }
        public string? NombreAlbum { get; set; }
        public int CantRepro { get; set; }
        public DateTime Lanzamiento { get; set; }
        public ushort IdBanda { get; set; }
        public ushort IdAlbum { get; set; }
        // public ushort IdBandaSeleccionado { get; set; }

        public VMAlbum()
        {

        }
        public VMAlbum(IEnumerable<Banda> bandas)
        {
            BandaList = new SelectList(bandas,
                                    dataTextField: nameof(Banda.Nombre),
                                    dataValueField: nameof(Banda.IdBanda));

        }
        // public VMAlbum(IEnumerable<Banda> bandas, Album album)
        // {
        //     BandaList = new SelectList(bandas,
        //                             dataTextField: nameof(Banda.Nombre),
        //                             dataValueField: nameof(Banda.IdBanda),
        //                             selectedValue: album.IdAlbum);

        // }
    }
}