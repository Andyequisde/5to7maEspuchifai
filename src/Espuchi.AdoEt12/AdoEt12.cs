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
    public void AltaBanda(Banda banda) => MapBanda.AltaBanda(banda);
    public List<Banda> ObtenerBanda() => MapBanda.ObtenerBanda();
    public Banda BandaPorId(ushort IdBanda) => MapBanda.BandaPorId(IdBanda);
    public void ActualizarBanda(Banda banda) => MapBanda.ActualizarBanda(banda);
    public void EliminarBanda(Banda banda) => MapBanda.EliminarBanda(banda);
    //----------------------------------------------------------------------------------------------
    public void AltaAlbum(Album album) => MapAlbum.AltaAlbum(album);
    public List<Album> ObtenerAlbum() => MapAlbum.ObetenerAlbum();
    //----------------------------------------------------------------------------------------------
}
