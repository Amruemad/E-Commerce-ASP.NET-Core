using Ecommerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<List<AppUser>> GetOne(int id);
        Task<List<AppUser>> GetOne(string username);
    }
}
