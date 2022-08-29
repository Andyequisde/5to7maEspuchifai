namespace Espuchi.Core
{
    public class Cancion
    {
        public ushort IdCancion { get; set; }
        public Album Album { get; set; }
        public string Nombre { get; set; }
        public uint NroOrden { get; set; }
        public int CantRepro { get; set; }

        public Cancion ( string nombre, uint nroOrden, int cantRepro, Album album)
        {
            Nombre = nombre;
            NroOrden = nroOrden;
            CantRepro = cantRepro;
            Album = album;
        }

    }
}