using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class ArticuloImg
    {
        Data.ArticuloImg _ArticuloImg = new Data.ArticuloImg();
        public Models.ArticuloImg Articulo_Imagen_registrar(Models.ArticuloImg cat_Atributos)
        {
            return _ArticuloImg.Articulo_Imagen_registrar(cat_Atributos);
        }
        public List<Models.ArticuloImg> ArticuloImgs_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            List<Models.ArticuloImg> articuloImgs = _ArticuloImg.ArticuloImgs_Seleccionar_IdArticulo(articulo);
            return articuloImgs;
        }

    }
}
