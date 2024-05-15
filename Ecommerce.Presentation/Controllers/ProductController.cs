using Ecommerce.DTOs.Product;
using Ecommerce.Presentation.Authorization;
using Ecommerce.Service.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var allProducts = await productService.GetAllProducts();

            if (allProducts != null)
            {
                return Ok(allProducts);
            }
            else
            {
                return NoContent();
            }
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await productService.GetOneProduct(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("category/{categoryId:int}")]
        public async Task<IActionResult> GetByCategory([FromRoute] int id)
        {
            var products = await productService.GetProductsOfCategory(id);

            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdateProductDTO newProduct)
        {
            await productService.CreateProduct(newProduct);
            return Ok("Created");
        }

        [Authorize("Admin")]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateOrUpdateProductDTO updateProduct)
        {
            var oldProductList = await productService.GetOneProduct(id);
            var oldProduct = oldProductList.FirstOrDefault();

            if (oldProduct == null)
            {
                return NotFound();
            }

            await productService.UpdateProduct(oldProduct, updateProduct);
            return Ok("Updated Successfully");
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool deleteResult = await productService.DeleteProduct(id);

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
