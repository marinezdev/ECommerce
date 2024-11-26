using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string TipoTelefono { get; set; }
        
        public string TelefonoMovil { get; set; }
        public string Password { get; set; }
        public string RepPassword { get; set; }
        public string NuPassword { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string RutaAcceso { get; set; }
        public string Ruta { get; set; }
        public string Mensaje { get; set; }

        public bool Session { get; set; }
        public string ClaveCoo { get; set; }
        public string FechaRegistro { get; set; }

        public int Total { get; set; }

        public int Invitacion { get; set; }
        public int IdCliente { get; set; }
    }
}
