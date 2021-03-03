using System;
using System.Collections.Generic;
using Orders.API.Core;

namespace Orders.API.Models
{
    public class OrderModel: BaseModel
    {
        public RecordSubjectModel RecordSubject { get; set; }
        public IEnumerable<LocationModel> Locations { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int OrderNumber { get; set; }
    }
}
