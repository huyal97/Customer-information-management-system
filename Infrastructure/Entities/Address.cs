using Infrastructure.Entities.ModelMetadataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Entities
{
    public class Address : BaseEntity
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [MaxLength(5)]
        public string ZipCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
