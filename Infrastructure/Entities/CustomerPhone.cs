using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class CustomerPhone : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
