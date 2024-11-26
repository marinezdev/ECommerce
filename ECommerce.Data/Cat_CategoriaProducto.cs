using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_CategoriaProducto
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_CategoriaProducto> Cat_CategoriaProducto_Listar()
        {
            const string consulta = "Cat_CategoriaProducto_Listar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_CategoriaProducto> resultado = new List<Models.Cat_CategoriaProducto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_CategoriaProducto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //public List<Models.Cat_CategoriaProducto> Cat_CategoriaProducto_Listar()
        //{
        //    b.ExecuteCommandSP("Cat_CategoriaProducto_Listar");
        //    List<Models.Cat_CategoriaProducto> resultado = new List<Models.Cat_CategoriaProducto>();
        //    var reader = b.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Models.Cat_CategoriaProducto item = new Models.Cat_CategoriaProducto()
        //        {
        //            Nombre = reader["Nombre"].ToString(),
        //            Id = Convert.ToInt32(reader["Id"]),
        //            UrlImg= reader["UrlImg"].ToString()
        //        };
        //        resultado.Add(item);
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;
        //}

        public Models.Cat_CategoriaProducto Cat_CategoriaProducto_Agregar(Models.Cat_CategoriaProducto cat_CategoriaProducto)
        {
            b.ExecuteCommandSP("Cat_CategoriaProducto_Agregar");
            b.AddParameter("@Nombre", cat_CategoriaProducto.Nombre, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", cat_CategoriaProducto.Id, SqlDbType.Int);

            Models.Cat_CategoriaProducto resultado = new Models.Cat_CategoriaProducto();
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
