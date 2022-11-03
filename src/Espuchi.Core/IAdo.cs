namespace Espuchi.Core;
public interface IAdo
{
    void AltaBanda(Banda banda);
    void AltaAlbum(Album album);
    Banda BandaPorId(ushort IdBanda);
    void ActualizarBanda(Banda banda);
    void EliminarBanda(Banda banda);
    List<Banda> ObtenerBanda();
    List<Album> ObtenerAlbum();

    List<Album> FiltrarAlbum(ushort IdBanda);
}