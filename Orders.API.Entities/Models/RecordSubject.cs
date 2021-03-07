using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Orders.API.Core;

namespace Orders.API.Entities.Models
{
    public class RecordSubject: BaseEntity
    {
        [Required]
        public CaseTypes CaseType { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PlaintiffName { get; set; }
        public string DefendantName { get; set; }
        public string Remarks { get; set; }
        public DateTime? TrialDate { get; set; }
        public bool IsRushed { get; set; }
        public bool IsBusinessRequest { get; set; }
        public bool IsClientRequest { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
