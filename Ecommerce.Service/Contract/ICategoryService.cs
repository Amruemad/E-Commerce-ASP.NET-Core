using Ecommerce.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Contract
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoriesDTO>> GetAllCategories();
        Task<IEnumerable<GetCategoriesDTO>> GetOneCategory(int id);
        Task CreateCategory(CreateOrUpdateCategoryDTO categoryDto);
        Task UpdateCategory(GetCategoriesDTO oldCat, CreateOrUpdateCategoryDTO editCat);
        Task<bool> DeleteCategory(int id);
    }
}
