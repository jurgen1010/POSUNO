using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Models
{
    public class Product
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        public decimal Price { get; set; }
        //Propiedad de lectura para darle formato al precio
        public string PriceString => $"{Price:C2}";

        public float Stock { get; set; }
        public string StockString => $"{Stock:N2}"; //Separador de miles

        public bool IsActive { get; set; }
        //Un producto pertenece a un usuario y usuario puede tener muchos productos (1 a muchos)
        
        public User User { get; set; }
    }
}
