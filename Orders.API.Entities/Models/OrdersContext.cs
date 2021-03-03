using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Orders.API.Entities.Models
{
    public class OrdersContext: DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>(entity => {
                entity.Property(e => e.OrderNumber)
                      .ValueGeneratedOnAdd()
                      .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<RecordSubject> RecordSubjects { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
