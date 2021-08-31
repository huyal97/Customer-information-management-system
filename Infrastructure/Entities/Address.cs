﻿using Infrastructure.Entities.ModelMetadataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Entities
{
    public class Address : BaseEntity
    {
        
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [MaxLength(5)]
        public string ZipCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
