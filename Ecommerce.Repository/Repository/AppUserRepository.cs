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
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        EcommerceContext ecommerceContext;

        public AppUserRepository(EcommerceContext _ecommerceContext) : base(_ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
        }

        public async Task<List<AppUser>> GetOne(int id)
        {
            return await dbSet.Where(au => au.Id == id).ToListAsync();
        }

        public async Task<List<AppUser>> GetOne(string username)
        {
            return await dbSet.Where(au => au.UserName == username).ToListAsync();
        }
    }
}
