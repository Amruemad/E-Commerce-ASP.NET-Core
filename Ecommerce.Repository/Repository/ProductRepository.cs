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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        EcommerceContext ecommerceContext;

        public ProductRepository(EcommerceContext _ecommerceContext) : base(_ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
        }

        public async Task<List<Product>> GetOne(int id)
        {
            return await dbSet.Where(p => p.ProdId == id).ToListAsync();
        }

        public async Task<List<Product>> GetByCat(int id)
        {
            return await dbSet.Where(p => p.CategricId == id).ToListAsync();
        }
    }
}
