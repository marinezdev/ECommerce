using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Usuarios_Direcciones
    {
        public int IdUsuario { get; set; }
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdPoblacion { get; set; }
        public string Poblacion { get; set; }
        public int IdColonia { get; set; }
        public string Colonia { get; set; }
        public int IdCP { get; set; }
        public string CP { get; set; }


        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string TipoTelefono { get; set; }
        public int Publicidad { get; set; }
        public int IdDireccion { get; set; }

        public string Calle { get; set; }
        public string NumExterior { get; set; }
        public string NumInteriror { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }

        public int Fiscal { get; set; }

        public int RecibirPedido { get; set; }
        public string Recibe_Nombre { get; set; }
        public string Recibe_Apellidos { get; set; }
        public string Recibe_Telefono { get; set; }
        public string Recibe_TipoTelefono { get; set; }


        public string Nombre_Direccion { get; set; }
    }
}
