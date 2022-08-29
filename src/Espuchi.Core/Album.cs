
namespace Espuchi.Core
{
    public class Album
    {
        public ushort IdAlbum { get; set; }
        public Banda Banda { get; set; }
        public string Nombre { get; set; }
        public DateOnly Lanzamiento { get; set; }
        public int CantRepro { get; set; }
        public List<Cancion> Canciones { get; set; }
        public Album(string nombre, DateOnly lanzamiento, int cantRepro, Banda banda)
        {
            Nombre = nombre;
            Lanzamiento = lanzamiento;
            CantRepro = cantRepro;
            Canciones = new List<Cancion>();
            Banda = banda;
        }
        public void AgregarCancion(Cancion cancion)
        {
            Canciones.Add(cancion);
        }
    }
}