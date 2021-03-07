using System;
using Orders.API.Core;

namespace Orders.API.Models
{
    public class LocationModel: BaseModel
    {
        public string Facility { get; set; }
        public string Department { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsToPresent { get; set; }
        public bool AnyAndAllRecords { get; set; }
        public RecordTypes RecordType { get; set; }
        public string ScopeDetails { get; set; }
        public Guid OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
