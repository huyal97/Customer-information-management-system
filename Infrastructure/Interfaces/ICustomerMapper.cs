using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface ICustomerMapper
    {
        public Customer CustomerDtoToCustomer(dynamic customerDto);
    }
}
