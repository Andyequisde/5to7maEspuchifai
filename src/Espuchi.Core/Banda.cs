namespace Espuchi.Core;
public class Banda
{
    public ushort IdBanda { get; set; }
    public string Nombre { get; set; }
    public DateTime Fundacion { get; set; }

    public Banda (ushort idBanda, string nombre, DateTime fundacion)
    {
        IdBanda = idBanda;
        Nombre = nombre;
        Fundacion = fundacion;
    }
}