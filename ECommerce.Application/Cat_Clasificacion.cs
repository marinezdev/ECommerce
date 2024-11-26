using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Clasificacion
    {
        Data.Cat_Clasificacion _cat_Clasificacion = new Data.Cat_Clasificacion();

        public List<Models.Cat_Clasificacion> Cat_Clasificacion_Listar(Models.Cat_Clasificacion cat_Clasificacion)
        {
            return _cat_Clasificacion.Cat_Clasificacion_Listar(cat_Clasificacion);
        }

        public Models.Cat_Clasificacion Cat_Clasificacion_Agregar(Models.Cat_Clasificacion cat_Clasificacion)
        {
            return _cat_Clasificacion.Cat_Clasificacion_Agregar(cat_Clasificacion);
        }
        public List<Models.Cat_Clasificacion> Cat_Clasificacion_PorId(Models.Cat_Clasificacion cat_Clasificacion)
        {
            return _cat_Clasificacion.Cat_Clasificacion_PorId(cat_Clasificacion);
        }
    }
}
