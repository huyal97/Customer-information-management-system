using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TcKimlik { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CustomerMail> Mails { get; set; }
        public List<CustomerPhone> PhoneNumbers { get; set; }
    }
}
