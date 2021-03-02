using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Orders.API.Core;

namespace Orders.API.Entities.Models
{
    public class Location: BaseEntity
    {
        [Required]
        public string Facility { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        public bool IsToPresent { get; set; }
        public bool AnyAndAllRecords { get; set; }
        [Required]
        public RecordTypes RecordType { get; set; }
        public string ScopeDetails { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
