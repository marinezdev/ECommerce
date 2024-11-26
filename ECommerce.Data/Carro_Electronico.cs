using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Carro_Electronico
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Mensaje Carro_Electronico_Registrar_Articulo(string Clave, Models.Carro_Electronico carro_Electronico)
        {
            b.ExecuteCommandSP("Carro_Electronico_Registrar_Articulo");
            b.AddParameter("@Clave", Clave, SqlDbType.NVarChar);
            b.AddParameter("@IdArticulo", carro_Electronico.IdArticulo, SqlDbType.Int);
            b.AddParameter("@Item ", carro_Electronico.Item, SqlDbType.Int);
            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Respuesta = Convert.ToBoolean(Convert.ToInt32(reader["Respuesta"].ToString()));
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Contenido = reader["Contenido"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Carro_Electronico Carro_Electronico_Consultar_Total(string Clave)
        {
            b.ExecuteCommandSP("Carro_Electronico_Consultar_Total");
            b.AddParameter("@Clave", Clave, SqlDbType.NVarChar);
            Models.Carro_Electronico resultado = new Models.Carro_Electronico();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Total = Convert.ToInt32(reader["Total"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }
        public List<Models.Carro_Electronico> Carro_Electronico_Listar_Articulos(string Clave)
        {
            b.ExecuteCommandSP("Carro_Electronico_Listar_Articulos");
            b.AddParameter("@Clave", Clave, SqlDbType.NVarChar);
            List<Models.Carro_Electronico> resultado = new List<Models.Carro_Electronico>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Carro_Electronico item = new Models.Carro_Electronico()
                {
                    Nombre = reader["Nombre"].ToString().ToUpper(),
                    Clasificacion = reader["Clasificacion"].ToString().ToUpper(),
                    Precio = reader["Precio"].ToString(),
                    PrecioText = reader["PrecioText"].ToString(),
                    Item = Convert.ToInt32(reader["Item"].ToString()),
                    Imagen = reader["Imagen"].ToString(),
                    TotalText = reader["TotalText"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    IdArticulo = Convert.ToInt32(reader["IdArticulo"].ToString()),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }
        public Models.Mensaje Carrito_Eliminar_Articulo(string Clave, Models.Carro_Electronico carro_Electronico)
        {
            b.ExecuteCommandSP("Carro_Electronico_Eliminar_Articulo");
            b.AddParameter("@Id", carro_Electronico.Id, SqlDbType.Int);
            b.AddParameter("@Clave", Clave, SqlDbType.NVarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Respuesta = Convert.ToBoolean(Convert.ToInt32(reader["Respuesta"].ToString()));
                resultado.RespuestaText = reader["RespuestaText"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Carro_Electronico Carrito_Actualizar(string Clave, Models.Carro_Electronico carro_Electronico)
        {
            b.ExecuteCommandSP("Carro_Electronico_Actualizar");
            b.AddParameter("@Clave", Clave, SqlDbType.NVarChar);
            b.AddParameter("@IdArticulo", carro_Electronico.IdArticulo, SqlDbType.Int);
            b.AddParameter("@Item", carro_Electronico.Item, SqlDbType.Int);

            Models.Carro_Electronico resultado = new Models.Carro_Electronico();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.TotalArticulo = reader["TotalArticulo"].ToString();
                resultado.TotalNota = reader["TotalNota"].ToString();
                resultado.IdArticulo = Convert.ToInt32(reader["IdArticulo"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
