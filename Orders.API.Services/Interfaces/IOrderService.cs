using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.Entities.Models;
using Orders.API.Models;

namespace Orders.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetAllOrders();
        Task<OrderModel> GetOrderById(Guid id);
        Task<OrderModel> GetOrderByNumber(int number);
        Task AddNewOrder(OrderModel order);
    }
}
