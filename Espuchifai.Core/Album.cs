using System;

namespace Espuchifai.Core
{
    public class Album
    {
        public short Id { get; set; }
        public Banda Banda { get; set; }
        public string Nombre { get; set; }
        public DateTime Lanzamiento{ get; set; }
    }
}
