using Ecommerce.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Contract
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrdersDTO>> GetAllOrders();
        Task<IEnumerable<GetOrdersDTO>>? GetOneOrder(int id);
        Task<IEnumerable<GetOrdersOfCustomerDTO>>? GetOrdersOfCustomer(int id);
        Task CreateOrder(CreateOrUpdateOrderDTO orderDto);
        Task UpdateOrder(GetOrdersDTO oldOrder, CreateOrUpdateOrderDTO editOrder);
        Task<bool> DeleteOrder(int id);
    }
}
