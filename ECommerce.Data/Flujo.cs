using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Flujo
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Flujo> Flujo_Listar()
        {
            b.ExecuteCommandSP("Flujo_Listar");
            List<Models.Flujo> resultado = new List<Models.Flujo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Flujo item = new Models.Flujo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Flujo Flujo_Agregar(Models.Flujo flujo)
        {
            b.ExecuteCommandSP("Flujo_Agregar");
            b.AddParameter("@Nombre", flujo.Nombre, SqlDbType.VarChar);

            Models.Flujo resultado = new Models.Flujo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
