using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_Poblacion
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Poblacion> Cat_Poblaciones_Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_Poblaciones_Seleccionar");
            b.AddParameter("@IdEstado", Id, SqlDbType.Int);
            List<Models.Cat_Poblacion> resultado = new List<Models.Cat_Poblacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Poblacion item = new Models.Cat_Poblacion()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Poblacion = reader["Poblacion"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
