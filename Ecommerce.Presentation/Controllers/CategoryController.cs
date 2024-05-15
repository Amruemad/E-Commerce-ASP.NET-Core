using Ecommerce.DTOs.Category;
using Ecommerce.DTOs.Product;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var allCategories = await categoryService.GetAllCategories();
            if (allCategories != null)
            {
                return Ok(allCategories);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await categoryService.GetOneCategory(id);

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateCategoryDTO newCategory)
        {
            await categoryService.CreateCategory(newCategory);
            return Ok("Created");
        }

        [HttpPut("update/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CreateOrUpdateCategoryDTO editCat)
        {
            var oldCatList = await categoryService.GetOneCategory(id);
            var oldCat = oldCatList.FirstOrDefault();

            if(oldCat == null)
            {
                return NotFound();
            }

            await categoryService.UpdateCategory(oldCat, editCat);
            return Ok("Updated Successfully");
        }

        [HttpDelete("delete/{id:int}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool deleteResult = await categoryService.DeleteCategory(id);

            if (deleteResult)
            {
                return Ok("Successfully Deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
