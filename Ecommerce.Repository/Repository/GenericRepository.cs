using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Context.Context;
using Ecommerce.Models.Models;
using Ecommerce.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        EcommerceContext ecommerceContext;
        protected DbSet<T> dbSet;

        public GenericRepository(EcommerceContext _ecommerceContext)
        {
            ecommerceContext = _ecommerceContext;
            dbSet = ecommerceContext.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task Save()
        {
            await ecommerceContext.SaveChangesAsync();
        }
    }
}
