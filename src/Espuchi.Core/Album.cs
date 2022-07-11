
namespace Espuchi.Core
{
    public class Album
    {
        public ushort IdAlbum { get; set; }
        public string Nombre { get; set; }
        public DateOnly Lanzamiento { get; set; }
        public int CantRepro { get; set; }

        public Album (ushort idAlbum ,string nombre, DateOnly lanzamiento, int cantRepro)
        {
            IdAlbum = idAlbum;
            Nombre = nombre;
            Lanzamiento = lanzamiento;
            CantRepro = cantRepro;
        }
    }
}