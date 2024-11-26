using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Cat_Atributos
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdClasificacion { get; set; }
        public string Atributo { get; set; }
        public string Valor { get; set; }
        public string TipoDato { get; set; }
        public int IdTipoDato { get; set; }
        public int IdArticulo { get; set; }
    }
}
