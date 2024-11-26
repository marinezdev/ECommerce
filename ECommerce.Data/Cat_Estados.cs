using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_Estados
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Estados> Cat_Estados_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Estados_Seleccionar");
            List<Models.Cat_Estados> resultado = new List<Models.Cat_Estados>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Estados item = new Models.Cat_Estados()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Estado = reader["Estado"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
