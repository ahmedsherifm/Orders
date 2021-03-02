using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;
using Orders.API.Models;
using Orders.API.Services.Interfaces;
using Orders.API.Utilities.AutoMapper;

namespace Orders.API.Services.Services
{
    public class OrderService: BaseService, IOrderService
    {
        public OrderService(IGenericRepository genericRepository, IMapperService mapperService) : base(genericRepository, mapperService)
        {
        }

        public async Task<List<OrderModel>> GetAllOrders()
        {
            return await GetAll<Order, OrderModel>();
        }

        public async Task<OrderModel> GetOrderById(Guid id)
        {
            return await GetById<Order, OrderModel>(id);
        }

        public async Task<OrderModel> GetOrderByNumber(string number)
        {
            var order = await GenericRepository.GetFirstAsync<Order>(o => o.OrderNumber == number);
            return MapperService.Map<Order, OrderModel>(order);
        }

        public async Task AddNewOrder(OrderModel orderModel)
        {
            var order = MapperService.Map<OrderModel, Order>(orderModel);
            GenericRepository.Add(order);
            await GenericRepository.SaveAsync();
        }
    }
}
