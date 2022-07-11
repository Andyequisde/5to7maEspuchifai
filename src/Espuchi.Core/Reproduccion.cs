namespace Espuchi.Core
{
    public class Reproduccion
    {
        public ushort IdReproduccion { get; set; }
        public DateTime MomentoRepro { get; set; }
        public Reproduccion (ushort idReproduccion, DateTime momentoRepro)
        {
            IdReproduccion = idReproduccion;
            MomentoRepro = momentoRepro;
        }
    }
}