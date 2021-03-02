using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Orders.API.DAL.Interfaces;
using Orders.API.Entities.Models;

namespace Orders.API.DAL.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly OrdersContext _ordersContext;

        public OrderRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersContext.Orders.Include(o => o.RecordSubject)
                .Include(o => o.Locations);
        }

        public Order GetOrderById(Guid id)
        {
            return _ordersContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public Order GetOrderByNumber(string number)
        {
            return _ordersContext.Orders.FirstOrDefault(o => o.OrderNumber == number);
        }

        public void AddNewOrder(Order order)
        {
            _ordersContext.Orders.Add(order);
            _ordersContext.SaveChanges();
        }
    }
}
