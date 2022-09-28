namespace Espuchi.Core;
public class Banda
{
    public ushort IdBanda { get; set; }
    public string Nombre { get; set; }
    public int Fundacion { get; set; }
    public List<Album> Albunes { get; set; }
    public Banda() => Albunes = new List<Album>();

    public Banda(string nombre, int fundacion) : this()
    {
        Nombre = nombre;
        Fundacion = fundacion;
    }
    public void AgregarAlbum(Album album)
        => Albunes.Add(album);
}