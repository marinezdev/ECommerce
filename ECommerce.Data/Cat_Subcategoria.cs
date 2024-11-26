using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_Subcategoria
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Subcategoria> Cat_Subcategoria_Listar(Models.Cat_CategoriaProducto cat_CategoriaProducto)
        {
            b.ExecuteCommandSP("Cat_Subcategoria_Listar");
            b.AddParameter("@Id", cat_CategoriaProducto.Id, SqlDbType.Int);
            List<Models.Cat_Subcategoria> resultado = new List<Models.Cat_Subcategoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Subcategoria item = new Models.Cat_Subcategoria()
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

        public Models.Cat_Subcategoria Cat_Subcategoria_Agregar(Models.Cat_Subcategoria cat_Subcategoria)
        {
            b.ExecuteCommandSP("Cat_Subcategoria_Agregar"); 
            b.AddParameter("@Nombre", cat_Subcategoria.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Imagen", cat_Subcategoria.Imagen, SqlDbType.VarChar);
            b.AddParameter("@IdCatCategoriaProducto", cat_Subcategoria.IdCatCategoriaProducto, SqlDbType.Int);
            b.AddParameter("@IdUsuario", cat_Subcategoria.Id, SqlDbType.Int);

            Models.Cat_Subcategoria resultado = new Models.Cat_Subcategoria();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Models.Cat_Subcategoria> Cat_Subcategoria_PorId(Models.Cat_Subcategoria cat_Subcategoria)
        {
            const string consulta = "Cat_Subcategoria_PorId";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", cat_Subcategoria.Id, SqlDbType.Int);

            List<Models.Cat_Subcategoria> resultado = new List<Models.Cat_Subcategoria>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Subcategoria>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
