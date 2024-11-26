using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Articulo
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Articulo Articulo_registrar(Models.Articulo articulo)
        {
            b.ExecuteCommandSP("Articulo_registrar");
            b.AddParameter("@IdCategoria", articulo.IdCategoria, SqlDbType.Int);
            b.AddParameter("@IdSubCategoria", articulo.IdSubCategoria, SqlDbType.Int);
            b.AddParameter("@IdClasificacion", articulo.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@IdFlujo", articulo.IdFlujo, SqlDbType.Int);
            b.AddParameter("@Nombre", articulo.Nombre, SqlDbType.VarChar);
            b.AddParameter("@SKU", articulo.SKU, SqlDbType.VarChar);
            b.AddParameter("@Stock", articulo.Stock, SqlDbType.VarChar);
            b.AddParameter("@Descripcion", articulo.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@Largo", articulo.Largo, SqlDbType.VarChar);
            b.AddParameter("@Ancho", articulo.Ancho, SqlDbType.VarChar);
            b.AddParameter("@Altura", articulo.Altura, SqlDbType.VarChar);
            b.AddParameter("@Peso", articulo.Peso, SqlDbType.VarChar);
            b.AddParameter("@Envio", articulo.Envio, SqlDbType.Int);
            b.AddParameter("@PrecioPublico", articulo.PrecioPublico, SqlDbType.VarChar);
            b.AddParameter("@PrecioDistribuidor", articulo.PrecioDistribuidor, SqlDbType.VarChar);
            b.AddParameter("@IdMoneda", articulo.IdMoneda, SqlDbType.Int);
            b.AddParameter("@Promocion", articulo.Promocion, SqlDbType.Int);
            b.AddParameter("@FechaInicio", articulo.FechaInicio, SqlDbType.NVarChar);
            b.AddParameter("@FechaFin", articulo.FechaFin, SqlDbType.NVarChar);
            b.AddParameter("@Precio", articulo.Precio, SqlDbType.NVarChar);
            b.AddParameter("@IdMonedaPromocion", articulo.IdMonedaPromocion, SqlDbType.Int);

            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Listar()
        {
            b.ExecuteCommandSP("Articulo_Listar");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    SKU = reader["SKU"].ToString(),
                    Informacion = reader["Informacion"].ToString(),
                    PrecioPublico = reader["PrecioPublico"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Articulo> Articulos_Store_Listar()
        {
            b.ExecuteCommandSP("Articulos_Store_Listar");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Clasificacion = reader["Clasificacion"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    PrecioText = reader["PrecioText"].ToString(),
                    Moneda =  reader["Moneda"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.ArticuloConsulta Articulo_Selecionar_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo_Selecionar_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            Models.Consultas.ArticuloConsulta resultado = new Models.Consultas.ArticuloConsulta();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.ArticuloConsulta>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
