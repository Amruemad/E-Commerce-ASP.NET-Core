using Ecommerce.Context.Context;
using Ecommerce.Models.Models;
using Ecommerce.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        EcommerceContext ecommerceContext;
        public OrderRepository(EcommerceContext _ecommerceContext) : base(_ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
        }

        public async Task<List<Order>> GetOne(int id)
        {
            return await dbSet.Where(o =>  o.OrderId == id).ToListAsync();
        }

        public async Task<List<Order>> GetOrderOfCustomer(int id)
        {
            return await dbSet.Where(o => o.AppUserId == id).ToListAsync();
        }
    }
}
