using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.API.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
