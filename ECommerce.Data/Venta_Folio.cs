using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Venta_Folio
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Consultas.VentaFolio Venta_Folio_Busqueda(Models.Venta_Folio venta_Folio)
        {
            const string consulta = "Venta_Folio_Busqueda";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Folio", venta_Folio.FolioCompuesto, SqlDbType.NVarChar);

            Models.Consultas.VentaFolio resultado = new Models.Consultas.VentaFolio();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.VentaFolio>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
