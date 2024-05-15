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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        EcommerceContext ecommerceContext;

        public CategoryRepository(EcommerceContext _ecommerceContext) : base(_ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
        }

        public async Task<List<Category>> GetOne(int id)
        {
            return await dbSet.Where(c => c.CatId == id).ToListAsync();
        }
    }
}
