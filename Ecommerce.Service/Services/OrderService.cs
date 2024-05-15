using AutoMapper;
using Ecommerce.DTOs.Order;
using Ecommerce.Models.Models;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        IMapper mapper;
        IOrderRepository orderRepo;

        public OrderService(IMapper _mapper, IOrderRepository _orderRepo)
        {
            mapper = _mapper;
            orderRepo = _orderRepo;
        }

        public async Task<IEnumerable<GetOrdersDTO>> GetAllOrders()
        {
            var allOrders = await orderRepo.GetAll();
            return mapper.Map<IEnumerable<GetOrdersDTO>>(allOrders);
        }

        public async Task<IEnumerable<GetOrdersDTO>>? GetOneOrder(int id)
        {
            var order = await orderRepo.GetOne(id);

            if (order == null)
            {
                return null;
            }
            else
            {
                return mapper.Map<IEnumerable<GetOrdersDTO>>(order);
            }
        }

        public async Task<IEnumerable<GetOrdersOfCustomerDTO>>? GetOrdersOfCustomer(int id)
        {
            var allCustOrders = await orderRepo.GetOrderOfCustomer(id);
            return mapper.Map<IEnumerable<GetOrdersOfCustomerDTO>>(allCustOrders);
        }

        public async Task CreateOrder(CreateOrUpdateOrderDTO orderDto)
        {
            var _order = mapper.Map<Order>(orderDto);
            await orderRepo.Add(_order);
            await orderRepo.Save();
        }

        public async Task UpdateOrder(GetOrdersDTO oldOrder, CreateOrUpdateOrderDTO editOrder)
        {
            oldOrder.AppUserId = editOrder.AppUserId;
            oldOrder.Products = editOrder.Products;

            var editiedOrder = mapper.Map<Order>(oldOrder);
            orderRepo.Update(editiedOrder);
            await orderRepo.Save();
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var delOrderList = await orderRepo.GetOne(id);
            var delOrder = delOrderList.FirstOrDefault();

            if (delOrder == null)
            {
                return false;
            }
            else
            {
                orderRepo.Delete(delOrder);
                await orderRepo.Save();
                return true;
            }
        }
    }
}
