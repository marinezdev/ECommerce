using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_CategoriaProducto
    {
        Data.Cat_CategoriaProducto _cat_CategoriaProducto = new Data.Cat_CategoriaProducto();
        public List<Models.Cat_CategoriaProducto> Cat_CategoriaProducto_Listar()
        {
            return _cat_CategoriaProducto.Cat_CategoriaProducto_Listar();
        }

        public Models.Cat_CategoriaProducto Cat_CategoriaProducto_Agregar(Models.Cat_CategoriaProducto cat_CategoriaProducto)
        {
            return _cat_CategoriaProducto.Cat_CategoriaProducto_Agregar(cat_CategoriaProducto);
        }

    }
}
