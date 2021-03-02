using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Orders.API.Entities.Models
{
    public class OrdersContext: DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<RecordSubject> RecordSubjects { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
