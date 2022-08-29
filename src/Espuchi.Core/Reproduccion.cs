namespace Espuchi.Core
{
    public class Reproduccion
    {
        public ushort IdReproduccion { get; set; }
        public DateTime MomentoRepro { get; set; }
        public Cancion Cancion { get; set; }
        public Cliente Cliente { get; set; }
        public Reproduccion ( DateTime momentoRepro, Cancion cancion, Cliente cliente )
        {
            MomentoRepro = momentoRepro;
            Cancion = cancion;
            Cliente = cliente;
        }
        
    }
}