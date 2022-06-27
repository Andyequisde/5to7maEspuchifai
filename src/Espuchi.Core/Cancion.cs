namespace Espuchi.Core
{
    public class Cancion
    {
        public string Nombre { get; set; }
        public uint NroOrden { get; set; }
        public int CantRepro { get; set; }
        public Cancion(string nombre, uint nroOrden, int cantRepro)
        {
            Nombre = nombre;
            NroOrden = nroOrden;
            CantRepro = cantRepro;
        }
    }
}