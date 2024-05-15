using AutoMapper;
using Ecommerce.DTOs.AppUsers;
using Ecommerce.DTOs.Category;
using Ecommerce.DTOs.Order;
using Ecommerce.DTOs.OrderProduct;
using Ecommerce.DTOs.Product;
using Ecommerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Product DTOs
            CreateMap<GetProductsDTO, Product>().ReverseMap();
            CreateMap<CreateOrUpdateProductDTO, Product>().ReverseMap();

            //Category DTOs
            CreateMap<GetCategoriesDTO, Category>().ReverseMap();
            CreateMap<CreateOrUpdateCategoryDTO, Category>().ReverseMap();

            //Order DTOs
            CreateMap<GetOrdersDTO, Order>().ReverseMap();
            CreateMap<GetOrdersOfCustomerDTO, Order>().ReverseMap();
            CreateMap<CreateOrUpdateOrderDTO, Order>().ReverseMap();

            //OrderProducts DTO
            CreateMap<OrderProductDTO, OrderProducts>().ReverseMap();

            //AppUser DTO
            CreateMap<GetAllUsersDTO, AppUser>().ReverseMap();
            CreateMap<CreateOrUpdateUserDTO, AppUser>().ReverseMap();
            CreateMap<LogUserDTO, AppUser>().ReverseMap();

        }
        
    }
}
