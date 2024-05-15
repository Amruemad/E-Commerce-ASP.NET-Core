using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task Save();
    }
}
