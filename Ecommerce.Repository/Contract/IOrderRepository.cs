using Ecommerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> GetOne(int id);
        Task<List<Order>> GetOrderOfCustomer(int id);
    }
}
