using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Services.Interfaces;

namespace Orders.API.Services.Services
{
    public class OrderService: BaseService, IOrderService
    {
        public OrderService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await GetAll<Order>();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await GetById<Order>(id);
        }

        public async Task<Order> GetOrderByNumber(string number)
        {
            return await GenericRepository.GetFirstAsync<Order>(o => o.OrderNumber == number);
        }

        public async Task AddNewOrder(Order order)
        {
            GenericRepository.Add(order);
            await GenericRepository.SaveAsync();
        }
    }
}
