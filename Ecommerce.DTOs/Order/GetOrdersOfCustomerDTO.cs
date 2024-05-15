using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTOs.Order
{
    public class GetOrdersOfCustomerDTO
    {
        public int OrderId { get; set; }
        public string CreationDate { get; set; } = string.Empty;
    }
}
