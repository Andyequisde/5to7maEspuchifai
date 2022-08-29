namespace Espuchi.Core
{
    public class Cliente
    {
        public ushort IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public List<Reproduccion> Reproducciones { get; set; }
        public Cliente (string nombre, string apellido, string email, string contraseña)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasena = contraseña;
            Reproducciones = new List<Reproduccion>();
        }
        //
        public void EscucharCancion(Cancion cancion)
        {
            Reproduccion unaReproduccion = new Reproduccion(DateTime.Now, cancion, this);
            Reproducciones.Add(unaReproduccion);
        }
    }
}