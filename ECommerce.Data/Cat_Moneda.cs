using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_Moneda
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Moneda> Cat_Moneda_Listar()
        {
            b.ExecuteCommandSP("Cat_Moneda_Listar");
            List<Models.Cat_Moneda> resultado = new List<Models.Cat_Moneda>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Moneda item = new Models.Cat_Moneda()
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
