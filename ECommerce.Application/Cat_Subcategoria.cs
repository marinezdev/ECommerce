using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Subcategoria
    {
        Data.Cat_Subcategoria _cat_Cat_Subcategoria = new Data.Cat_Subcategoria();
        public List<Models.Cat_Subcategoria> Cat_Subcategoria_Listar(Models.Cat_CategoriaProducto cat_CategoriaProducto)
        {
            return _cat_Cat_Subcategoria.Cat_Subcategoria_Listar(cat_CategoriaProducto);
        }

        public Models.Cat_Subcategoria Cat_Subcategoria_Agregar(Models.Cat_Subcategoria cat_Subcategoria)
        {
            return _cat_Cat_Subcategoria.Cat_Subcategoria_Agregar(cat_Subcategoria);
        }
        public List<Models.Cat_Subcategoria> Cat_Subcategoria_PorId(Models.Cat_Subcategoria cat_Subcategoria)
        {
            return _cat_Cat_Subcategoria.Cat_Subcategoria_PorId(cat_Subcategoria);
        }
        
    }
}
