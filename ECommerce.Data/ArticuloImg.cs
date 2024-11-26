using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ECommerce.Data
{
    public class ArticuloImg
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ArticuloImg Articulo_Imagen_registrar(Models.ArticuloImg articuloImg)
        {
            b.ExecuteCommandSP("Articulo_Imagen_registrar");
            b.AddParameter("@IdArticulo", articuloImg.IdArticulo, SqlDbType.Int);
            b.AddParameter("@IdArchivo", articuloImg.IdArchivo, SqlDbType.Int);
            b.AddParameter("@NmArchivo", articuloImg.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", articuloImg.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@ImagenURL", articuloImg.ImagenURL, SqlDbType.NVarChar);

            Models.ArticuloImg resultado = new Models.ArticuloImg();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ArticuloImg> ArticuloImgs_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo_Imagenes_Seleccionar_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            List<Models.ArticuloImg> resultado = new List<Models.ArticuloImg>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ArticuloImg>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
