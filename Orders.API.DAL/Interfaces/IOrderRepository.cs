using System;
using System.Collections.Generic;
using System.Text;
using Orders.API.Entities.Models;

namespace Orders.API.DAL.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(Guid id);
        Order GetOrderByNumber(string number);
        void AddNewOrder(Order order);
    }
}
