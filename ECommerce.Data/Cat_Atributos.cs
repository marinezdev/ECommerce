using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cat_Atributos
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Atributos> Cat_Atributos_Listar(Models.Cat_Atributos cat_Atributos)
        {
            b.ExecuteCommandSP("Cat_Atributos_Listar");
            b.AddParameter("@IdCategoria", cat_Atributos.IdCategoria, SqlDbType.Int);
            b.AddParameter("@IdSubCategoria", cat_Atributos.IdSubCategoria, SqlDbType.Int);
            b.AddParameter("@IdClasificacion", cat_Atributos.IdClasificacion, SqlDbType.Int);
            List<Models.Cat_Atributos> resultado = new List<Models.Cat_Atributos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Atributos item = new Models.Cat_Atributos()
                {
                    TipoDato = reader["TipoDato"].ToString(),
                    Atributo = reader["Atributo"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Atributos Atributo_Agregar(Models.Cat_Atributos cat_Atributos)
        {
            b.ExecuteCommandSP("Atributo_Agregar");
            b.AddParameter("@IdCategoria", cat_Atributos.IdCategoria, SqlDbType.Int);
            b.AddParameter("@IdSubCategoria", cat_Atributos.IdSubCategoria, SqlDbType.Int);
            b.AddParameter("@IdClasificacion", cat_Atributos.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@IdTipoDato", cat_Atributos.IdTipoDato, SqlDbType.Int);
            b.AddParameter("@Atributo", cat_Atributos.Atributo, SqlDbType.NVarChar);

            Models.Cat_Atributos resultado = new Models.Cat_Atributos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Atributos Atributo_Eliminar(Models.Cat_Atributos cat_Atributos)
        {
            b.ExecuteCommandSP("Atributo_Eliminar");
            b.AddParameter("@Id", cat_Atributos.Id, SqlDbType.Int);

            Models.Cat_Atributos resultado = new Models.Cat_Atributos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Atributos Atributo_Buscar_Id(Models.Cat_Atributos cat_Atributos)
        {
            b.ExecuteCommandSP("Atributo_Buscar_Id");
            b.AddParameter("@Id", cat_Atributos.Id, SqlDbType.Int);

            Models.Cat_Atributos resultado = new Models.Cat_Atributos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Atributo = reader["Atributo"].ToString();
                resultado.IdTipoDato = Convert.ToInt32(reader["IdTipoDato"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_Atributos Atributo_Editar(Models.Cat_Atributos cat_Atributos)
        {
            b.ExecuteCommandSP("Atributo_Editar");
            b.AddParameter("@Id", cat_Atributos.Id, SqlDbType.Int);
            b.AddParameter("@Atributo", cat_Atributos.Atributo, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoDato", cat_Atributos.IdTipoDato, SqlDbType.Int);

            Models.Cat_Atributos resultado = new Models.Cat_Atributos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.Cat_Atributos Articulo_Atributo_registrar(Models.Cat_Atributos cat_Atributos)
        {
            b.ExecuteCommandSP("Articulo_Atributo_registrar");
            b.AddParameter("@IdArticulo", cat_Atributos.IdArticulo, SqlDbType.Int);
            b.AddParameter("@IdAtributo", cat_Atributos.Id, SqlDbType.Int);
            b.AddParameter("@Valor", cat_Atributos.Valor, SqlDbType.NVarChar);

            Models.Cat_Atributos resultado = new Models.Cat_Atributos();
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
