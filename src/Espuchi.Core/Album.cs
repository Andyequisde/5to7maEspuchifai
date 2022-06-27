namespace Espuchi.Core
{
    public class Album
    {
        public string Nombre { get; set; }
        public DateOnly Lanzamiento { get; set; }
        public int CantRepro { get; set; }
        public Album(string nombre, DateOnly lanzamiento, int cantRepro)
        {
            Nombre = nombre;
            Lanzamiento = lanzamiento;
            CantRepro = cantRepro;
        }
    }
}