namespace Espuchi.Core;
public interface IAdo
{
    void AltaBanda(Banda banda);
    void AltaAlbum(Album album);
    Banda BandaPorId(ushort IdBanda);
    void ActualizarBanda(Banda banda);
    List<Banda> ObtenerBanda();
    List<Album> ObtenerAlbum();
}