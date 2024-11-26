using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ECommerce.Data
{
    public class Cat_Clasificacion
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Clasificacion> Cat_Clasificacion_Listar(Models.Cat_Clasificacion cat_Clasificacion)
        {
            b.ExecuteCommandSP("Cat_Clasificacion_Listar");
            b.AddParameter("@IdCatSubcategoria", cat_Clasificacion.IdCatSubcategoria, SqlDbType.Int);
            List<Models.Cat_Clasificacion> resultado = new List<Models.Cat_Clasificacion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Clasificacion item = new Models.Cat_Clasificacion()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Clasificacion Cat_Clasificacion_Agregar(Models.Cat_Clasificacion cat_Clasificacion)
        {
            b.ExecuteCommandSP("Cat_Clasificacion_Agregar");
            b.AddParameter("@Nombre", cat_Clasificacion.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Imagen", cat_Clasificacion.Imagen, SqlDbType.VarChar);
            b.AddParameter("@IdCatSubcategoria", cat_Clasificacion.IdCatSubcategoria, SqlDbType.Int);
            b.AddParameter("@IdUsuario", cat_Clasificacion.Id, SqlDbType.Int);

            Models.Cat_Clasificacion resultado = new Models.Cat_Clasificacion();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.Cat_Clasificacion> Cat_Clasificacion_PorId(Models.Cat_Clasificacion cat_Clasificacion)
        {
            const string consulta = "Cat_Clasificacion_PorId";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", cat_Clasificacion.Id, SqlDbType.Int);

            List<Models.Cat_Clasificacion> resultado = new List<Models.Cat_Clasificacion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Clasificacion>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
