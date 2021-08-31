using API.Dtos;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer CustomerDtoToCustomer(dynamic customerDto)
        {
            Customer customer = new Customer();
            customer.Addresses = new List<Address>();
            customer.Mails = new List<CustomerMail>();
            customer.PhoneNumbers = new List<CustomerPhone>();

            customer.Name = customerDto.Name;
            customer.LastName = customerDto.LastName;
            customer.TcKimlik = customerDto.TcKimlik;

            customer.Addresses.Add(customerDto.Address);
            customer.Mails.Add(customerDto.CustomerMail);
            customer.PhoneNumbers.Add(customerDto.CustomerPhoneNumber);

            return customer;
        }       
    }
}
