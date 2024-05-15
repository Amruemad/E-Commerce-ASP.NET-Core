using AutoMapper;
using Ecommerce.DTOs.Category;
using Ecommerce.Models.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class CategoryService : ICategoryService
    {
        IMapper mapper;
        ICategoryRepository categoryRepo;

        public CategoryService(IMapper _mapper, ICategoryRepository _categoryRepository)
        {
            mapper = _mapper;
            categoryRepo = _categoryRepository;
        }


        public async Task<IEnumerable<GetCategoriesDTO>>? GetAllCategories()
        {
            var allCategories = await categoryRepo.GetAll();
            return mapper.Map<IEnumerable<GetCategoriesDTO>>(allCategories);
        }

        public async Task<IEnumerable<GetCategoriesDTO>>? GetOneCategory(int id)
        {
            var category = await categoryRepo.GetOne(id);

            if (category == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<IEnumerable<GetCategoriesDTO>>(category);
            }
        }

        public async Task CreateCategory(CreateOrUpdateCategoryDTO categoryDto)
        {
            var _category = mapper.Map<Category>(categoryDto);
            await categoryRepo.Add(_category);
            await categoryRepo.Save();
        }

        public async Task UpdateCategory(GetCategoriesDTO oldCat, CreateOrUpdateCategoryDTO editCat)
        {
            oldCat.Name = editCat.Name;

            var editedCategory = mapper.Map<Category>(oldCat);
            categoryRepo.Update(editedCategory);

            await categoryRepo.Save();
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var delCategoryList = await categoryRepo.GetOne(id);
            var delCategory = delCategoryList.FirstOrDefault();

            if (delCategory == null)
            {
                return false;
            }
            else
            {
                categoryRepo.Delete(delCategory);
                await categoryRepo.Save();
                return true;
            }
        }
    }
}
