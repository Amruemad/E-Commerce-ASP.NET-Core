using Ecommerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetOne(int id);
    }
}
