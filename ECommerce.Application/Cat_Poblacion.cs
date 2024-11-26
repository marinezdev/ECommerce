using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Poblacion
    {
        Data.Cat_Poblacion _cat_Poblacion = new Data.Cat_Poblacion();
        public List<Models.Cat_Poblacion> Cat_Poblaciones_Seleccionar(int Id)
        {
            return _cat_Poblacion.Cat_Poblaciones_Seleccionar(Id);
        }
    }
}
