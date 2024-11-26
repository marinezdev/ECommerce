using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_TipoDatos
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_TipoDatos> Cat_TipoDatos_Listar()
        {
            b.ExecuteCommandSP("Cat_TipoDatos_Listar");
            List<Models.Cat_TipoDatos> resultado = new List<Models.Cat_TipoDatos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_TipoDatos item = new Models.Cat_TipoDatos()
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
    }
}
