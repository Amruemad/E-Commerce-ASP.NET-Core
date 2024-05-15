using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public bool Available { get; set; } = true;
        
        //Relation with category
        public Category? Category { get; set; } // Navigation to Category class
        public int? CategricId { get; set; } // Category forign key

        //Relation with products ==> Many to many relation ==> Third table(OrderProducts)
        public List<OrderProducts>? Orders { get; set; }
    }
}
