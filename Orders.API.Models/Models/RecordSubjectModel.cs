using System;
using Orders.API.Core;

namespace Orders.API.Models
{
    public class RecordSubjectModel: BaseModel
    {
        public CaseTypes CaseType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PlaintiffName { get; set; }
        public string DefendantName { get; set; }
        public string Remarks { get; set; }
        public DateTime TrialDate { get; set; }
        public bool IsRushed { get; set; }
        public bool IsBusinessRequest { get; set; }
        public bool IsClientRequest { get; set; }
        public Guid OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
