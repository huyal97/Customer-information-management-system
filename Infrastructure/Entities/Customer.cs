using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CustomerMail> Mails { get; set; }
        public List<CustomerPhone> PhoneNumbers { get; set; }
    }
}
