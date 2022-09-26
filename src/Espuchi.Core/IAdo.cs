namespace Espuchi.Core;
public interface IAdo
{
    void AltaBanda(Banda banda);
    void AltaAlbum(Album album);
    List<Banda> ObtenerBanda();
    List<Album> ObtenerAlbum();
}