using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTOs.OrderProduct;
using Ecommerce.Models.Models;

namespace Ecommerce.DTOs.Order
{
    public class CreateOrUpdateOrderDTO
    {
        public int? AppUserId { get; set; }
        public List<OrderProductDTO>? Products { get; set; }
    }
}
