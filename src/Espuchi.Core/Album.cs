namespace Espuchi.Core;
public class Album
{
    public ushort IdAlbum { get; set; }
    public Banda? Banda { get; set; }
    public string Nombre { get; set; }
    public DateTime Lanzamiento { get; set; }
    public int CantRepro { get; set; }
    public List<Cancion> Canciones { get; set; }
    
    public Album(string nombre, DateTime lanzamiento, int cantRepro)
    {
        Nombre = nombre;
        Lanzamiento = lanzamiento;
        CantRepro = cantRepro;
        Canciones = new List<Cancion>();
    }
    public Album(string nombre, DateTime lanzamiento, int cantRepro, Banda? banda = null)
        : this(nombre, lanzamiento, cantRepro) => Banda = banda;
    public void AgregarCancion(Cancion cancion) => Canciones.Add(cancion);
}