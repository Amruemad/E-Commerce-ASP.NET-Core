using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;

        // Relation with customers
        public int? AppUserId { get; set; }
        public AppUser? Customer { get; set; }

        //Relation with products ==> Many to many relation ==> Third table(OrderProducts)
        public List<OrderProducts>? Products { get; set; }
    }
}
