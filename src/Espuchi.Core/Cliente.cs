namespace Espuchi.Core
{
    public class Cliente
    {
        public ushort IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        
        public Cliente (ushort idCliente, string nombre, string apellido, string email, string contraseña)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasena = contraseña;
        }
    }
}