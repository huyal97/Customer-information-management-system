using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class CustomerMail : BaseEntity
    {
        public string Mail { get; set; }
        public int CustomerId { get; set; }
    }
}
