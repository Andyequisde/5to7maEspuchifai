using System.Collections.Generic;

namespace Espuchi.Core;
public class Banda
{
    public ushort Id { get; set; }
    public string Nombre { get; set; }
    public DateTime Fundacion { get; set; }
    public List<Album> Albunes { get; set; }

    public Banda (ushort id, string nombre, DateTime fundacion)
    {
        Id = id;
        Nombre = nombre;
        Fundacion = fundacion;
        Albunes = new List<Album>();
    }
    public void AgregarAlbum(Album album)
    {
        Albunes.Add(album);
    }
}