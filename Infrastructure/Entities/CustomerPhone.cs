using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Entities
{
    public class CustomerPhone : BaseEntity
    {
        [Required]
        [StringLength(11, MinimumLength = 11)]

        public string PhoneNumber { get; set; }
        public int CustomerId { get; set; }
    }
}
