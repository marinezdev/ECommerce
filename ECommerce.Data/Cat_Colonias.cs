using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_Colonias
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_Colonias> Cat_Colonias_Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_Colonias_Seleccionar");
            b.AddParameter("@IdPolacion", Id, SqlDbType.Int);
            List<Models.Cat_Colonias> resultado = new List<Models.Cat_Colonias>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Colonias item = new Models.Cat_Colonias()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Colonia = reader["Colonia"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
