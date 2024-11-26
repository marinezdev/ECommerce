using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Atributos
    {
        Data.Cat_Atributos _cat_Atributos = new Data.Cat_Atributos();
        public List<Models.Cat_Atributos> Cat_Atributos_Listar(Models.Cat_Atributos cat_Atributos)
        {
            return _cat_Atributos.Cat_Atributos_Listar(cat_Atributos);
        }
        public Models.Cat_Atributos Atributo_Agregar(Models.Cat_Atributos cat_Atributos)
        {
            return _cat_Atributos.Atributo_Agregar(cat_Atributos);
        }
        public Models.Cat_Atributos Atributo_Eliminar(Models.Cat_Atributos cat_Atributos)
        {
            return _cat_Atributos.Atributo_Eliminar(cat_Atributos);
        }

        public Models.Cat_Atributos Atributo_Buscar_Id(Models.Cat_Atributos cat_Atributos)
        {
            return _cat_Atributos.Atributo_Buscar_Id(cat_Atributos);
        }

        public Models.Cat_Atributos Atributo_Editar(Models.Cat_Atributos cat_Atributos)
        {
            return _cat_Atributos.Atributo_Editar(cat_Atributos);
        }

        public Models.Cat_Atributos Articulo_Atributo_registrar(Models.Cat_Atributos cat_Atributos)
        {
            return _cat_Atributos.Articulo_Atributo_registrar(cat_Atributos);
        }
    }
}
