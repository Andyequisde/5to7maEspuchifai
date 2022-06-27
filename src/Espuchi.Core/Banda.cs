namespace Espuchi.Core;
public class Banda
{
    public string Nombre { get; set; }
    public DateTime Fundacion { get; set; }
    public Banda (string nombre, DateTime fundacion)
    {
        Nombre = nombre;
        Fundacion = fundacion;
    }
}