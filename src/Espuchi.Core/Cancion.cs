namespace Espuchi.Core
{
    public class Cancion
    {
        public ushort IdCancion { get; set; }
        public Album Album { get; set; }
        public string Nombre { get; set; }
        public uint NroOrden { get; set; }
        public int CantRepro { get; set; }

        public Cancion (ushort idCancion, string nombre, uint nroOrden, int cantRepro, Album album)
        {
            IdCancion = idCancion;
            Nombre = nombre;
            NroOrden = nroOrden;
            CantRepro = cantRepro;
            Album = album;
        }
    }
}