using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ArticulosAtributos
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Consultas.ArticuloAtributos> Articulo_Atributos_Selecionar(Models.Articulo articulo)
        {
            const string consulta = "Articulo_Atributos_Selecionar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.NVarChar);

            List<Models.Consultas.ArticuloAtributos> resultado = new List<Models.Consultas.ArticuloAtributos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.ArticuloAtributos>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
