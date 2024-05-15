using Ecommerce.DTOs.OrderProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTOs.Order
{
    public class GetOrdersDTO
    {
        public int? AppUserId { get; set; }
        public string CreationDate { get; set; } = string.Empty;
        public List<OrderProductDTO>? Products { get; set; }

    }
}
