using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string Name { get; set; } = string.Empty;

        //Relation with products
        public List<Product>? Products { get; set; }
    }
}
