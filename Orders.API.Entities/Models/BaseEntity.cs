using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.API.Entities.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDate = UpdatedDate = DateTimeOffset.Now;
        }
    }
}
