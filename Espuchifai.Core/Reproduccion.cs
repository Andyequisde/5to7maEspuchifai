namespace Espuchifai.Core
{
    public class Reproduccion

    {
        public short Id { get; set; }
        public Cancion Cancion { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Momento_reproduccion { get; set; }
    }
}