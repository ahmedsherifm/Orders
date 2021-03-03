using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Orders.API.Core;

namespace Orders.API.Entities.Models
{
    public class Order: BaseEntity
    {
        public RecordSubject RecordSubject { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.InProgress;
        public int OrderNumber { get; set; }
    }
}
