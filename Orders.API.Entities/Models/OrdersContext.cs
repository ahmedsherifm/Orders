using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Orders.API.Entities.Models
{
    public class OrdersContext: IdentityDbContext<ApplicationUser>
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
