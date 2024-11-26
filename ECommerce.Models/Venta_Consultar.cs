using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Venta_Consultar
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string FechaRegistro { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public string Poblacion { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string NombreDireccion { get; set; }
        public string NumExterior { get; set; }
        public string NumInteriror { get; set; }
        public string Calle { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }
        public int Fiscal { get; set; }
        public int Flag { get; set; }
        public int RecibirPedido { get; set; }
        public string Recibe_Nombre { get; set; }
        public string Recibe_Apellidos { get; set; }
        public string Recibe_Telefono { get; set; }
        public string Recibe_TipoTelefono { get; set; }
        public string MetodoPago { get; set; }
        public string Referencia { get; set; }
        public string PrecioText { get; set; }
    }
}
