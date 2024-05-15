using Ecommerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetOne(int id);

        Task<List<Product>> GetByCat(int id);
    }
}
