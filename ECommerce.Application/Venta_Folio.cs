using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Venta_Folio
    {
        Data.Venta_Folio _Venta_Folio = new Data.Venta_Folio();

        public Models.Consultas.VentaFolio Venta_Folio_Busqueda(Models.Venta_Folio venta_Folio)
        {
            return _Venta_Folio.Venta_Folio_Busqueda(venta_Folio);
        }
    }
}
