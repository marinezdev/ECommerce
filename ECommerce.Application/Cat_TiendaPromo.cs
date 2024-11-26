using System;
using System.Collections.Generic;

namespace ECommerce.Application
{
	public class Cat_TiendaPromo
	{
			Data.Cat_TiendaPromo _cat_TiendaPromo = new Data.Cat_TiendaPromo();

            public List<Models.Cat_TiendaPromo> Cat_TiendaPromo_Listar(int num) 
            {
                return _cat_TiendaPromo.Cat_TiendaPromo_Listar(num);
            }
        
	}
}

