using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_FlujoBase
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_FlujoBase> Cat_FlujoBase_Listar(Models.Flujo flujo)
        {
            b.ExecuteCommandSP("Cat_FlujoBase_Listar");
            List<Models.Cat_FlujoBase> resultado = new List<Models.Cat_FlujoBase>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_FlujoBase item = new Models.Cat_FlujoBase()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Etapa = Convert.ToInt32(reader["Etapa"]),
                    Id = Convert.ToInt32(reader["Id"]),
                    IdFlujo = flujo.Id,
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
