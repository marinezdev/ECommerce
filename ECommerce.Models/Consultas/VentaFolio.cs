using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class VentaFolio
    {
        public Venta Venta { get; set; }
        public Venta_Folio Venta_Folio { get; set; }
        public Cat_EstatusVenta Cat_EstatusVenta { get; set; }
        public Cat_TipoCliete Cat_TipoCliete { get; set; }
        public Cat_MetodoPago Cat_MetodoPago { get; set; }
        public Usuarios Usuarios { get; set; }
        public Usuarios_Direcciones Usuarios_Direcciones { get; set; }
        public Cat_Estados Cat_Estados { get; set; }
        public Cat_Poblacion Cat_Poblacion { get; set; }
        public Cat_Colonias Cat_Colonias { get; set; }
        public Cat_CP Cat_CP { get; set; }
    }
}
