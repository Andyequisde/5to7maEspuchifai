using System.Collections.Generic;

namespace Espuchi.Core;
public class Banda
{
    public ushort IdBanda { get; set; }
    public string Nombre { get; set; }
    public int Fundacion { get; set; }
    public List<Album> Albunes { get; set; }

    public Banda (string nombre, int fundacion)
    {

        Nombre = nombre;
        Fundacion = fundacion;
        Albunes = new List<Album>();
    }
    public void AgregarAlbum(Album album)
    {
        Albunes.Add(album);
    }
}