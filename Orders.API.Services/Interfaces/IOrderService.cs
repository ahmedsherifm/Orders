using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.Entities.Models;

namespace Orders.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid id);
        Task<Order> GetOrderByNumber(string number);
        Task AddNewOrder(Order order);
    }
}
