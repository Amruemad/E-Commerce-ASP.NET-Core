using Ecommerce.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductsDTO>> GetAllProducts();
        Task<IEnumerable<GetProductsDTO>>? GetOneProduct(int id);
        Task<IEnumerable<GetProductsDTO>>? GetProductsOfCategory(int id);
        Task CreateProduct(CreateOrUpdateProductDTO productDto);
        Task UpdateProduct(GetProductsDTO oldProduct,CreateOrUpdateProductDTO editProduct);
        Task<bool> DeleteProduct(int id);
    }
}
