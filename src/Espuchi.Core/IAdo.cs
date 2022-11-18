namespace Espuchi.Core;
public interface IAdo
{
    Task AltaBanda(Banda banda);
    Task ActualizarBanda(Banda banda);
    Task<Banda> BandaPorId(ushort IdBanda);
    Task EliminarBanda(Banda banda);
    Task<List<Banda>> ObtenerBanda();
    Task AltaAlbum(Album album);
    Task<List<Album>> ObtenerAlbum();
    Task<List<Album>> FiltrarAlbum(ushort IdBanda);
}