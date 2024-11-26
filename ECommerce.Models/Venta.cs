using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        public string FechaRegistro { get; set; }
        public string Estatus { get; set; }
        public string PrecioText { get; set; }
        public string Etapa { get; set; }
        public decimal Total { get; set; }

        public int IdUsuario { get; set; }
        public int IdMetoPago { get; set; }
        public int IdDireccion { get; set; }
        public string Referencia { get; set; }

        public string Clave { get; set; }
    }
}
