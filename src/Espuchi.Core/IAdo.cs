namespace Espuchi.Core;
public interface IAdo
{
    void AltaBanda(Banda banda);
    void AltaAlbum(Album Album);
    List<Banda> ObtenerBanda();

    List<Album> ObtenerAlbum();
    Banda BandaPorId(ushort idBanda);
}