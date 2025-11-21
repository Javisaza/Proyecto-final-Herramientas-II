using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Clases
{
    public class UsuarioActual
    {
        public int? IdUsuario { get; set; }   // Puede ser null si es invitado
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }    
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor vacío para invitado
        public UsuarioActual()
        {
            Rol = "Invitado";
        }

        // Constructor con datos
        public UsuarioActual(int id, string nombre, string apellido, string email, string username, string password, string rol )
        {
            IdUsuario = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Rol = rol;
            Username=username;
            Password=password;
        }

        // Método de utilidad
        public bool EsInvitado()
        {
            return Rol == "Invitado";
        }
    }
}
