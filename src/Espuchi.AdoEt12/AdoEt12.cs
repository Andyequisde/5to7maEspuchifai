using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using Espuchi.Core;

namespace Espuchi.AdoEt12;
public class AdoEt12 : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapBanda MapBanda { get; set; }
    public MapAlbum MapAlbum { get; set; }
    public AdoEt12(AdoAGBD ado)
    {
        Ado = ado;
        MapBanda = new MapBanda(ado);
        MapAlbum = new MapAlbum(ado);
    }
    //---------------------------------------------------------------------------------------------
    public async Task AltaBanda(Banda banda) => await MapBanda.AltaBanda(banda);
    public async Task<List<Banda>> ObtenerBanda() => await MapBanda.ObtenerBanda();
    public async Task<Banda> BandaPorId(ushort IdBanda) => await MapBanda.BandaPorId(IdBanda);
    public async Task ActualizarBanda(Banda banda) => await MapBanda.ActualizarBanda(banda);
    public async Task EliminarBanda(Banda banda) => await MapBanda.EliminarBanda(banda);
    //----------------------------------------------------------------------------------------------
    public async Task AltaAlbum(Album album) => await MapAlbum.AltaAlbum(album);
    public async Task<List<Album>> ObtenerAlbum() => await MapAlbum.ObetenerAlbum();

    public async Task<List<Album>> FiltrarAlbum(ushort IdBanda)
        => await MapAlbum.FilasFiltradasAsync("IdBanda", IdBanda);
    //----------------------------------------------------------------------------------------------
}
