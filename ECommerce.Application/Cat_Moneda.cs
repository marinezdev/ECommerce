using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cat_Moneda
    {
        Data.Cat_Moneda _Cat_Moneda = new Data.Cat_Moneda();
        public List<Models.Cat_Moneda> Cat_Moneda_Listar()
        {
            return _Cat_Moneda.Cat_Moneda_Listar();
        }
    }
}
