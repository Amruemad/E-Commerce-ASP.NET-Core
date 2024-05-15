using AutoMapper;
using Ecommerce.DTOs.Product;
using Ecommerce.Models.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.Repository;
using Ecommerce.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepo;
        IMapper mapper;

        public ProductService(IProductRepository _productRepo, IMapper _mapper)
        {
            productRepo = _productRepo;
            mapper = _mapper;
        }


        public async Task<IEnumerable<GetProductsDTO>> GetAllProducts()
        {
            var AllProducts = await productRepo.GetAll();
            return mapper.Map<IEnumerable<GetProductsDTO>>(AllProducts);
        }

        public async Task<IEnumerable<GetProductsDTO>>? GetOneProduct(int id)
        {
            var product = await productRepo.GetOne(id);

            if (product == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<IEnumerable<GetProductsDTO>>(product);
            }
        }

        public async Task<IEnumerable<GetProductsDTO>>? GetProductsOfCategory(int id)
        {
            var products = await productRepo.GetByCat(id);

            if(products == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<IEnumerable<GetProductsDTO>>(products);
            }
        }

        public async Task CreateProduct(CreateOrUpdateProductDTO productDto)
        {
            var _product = mapper.Map<Product>(productDto);
            await productRepo.Add(_product);
            await productRepo.Save();
        }

        public async Task UpdateProduct(GetProductsDTO oldProduct,
            CreateOrUpdateProductDTO editProduct)
        {
            oldProduct.CatId = editProduct.CatId;
            oldProduct.Price = editProduct.Price;
            oldProduct.Name = editProduct.Name;
            oldProduct.Description = editProduct.Description;

            var editedProduct = mapper.Map<Product>(oldProduct);
            productRepo.Update(editedProduct);

            await productRepo.Save();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var delProductList = await productRepo.GetOne(id);
            var delProduct =  delProductList.FirstOrDefault();
            if (delProduct == null)
            {
                return false;
            }
            else
            {
                productRepo.Delete(delProduct);
                await productRepo.Save();
                return true;
            }
        }
    }
}
