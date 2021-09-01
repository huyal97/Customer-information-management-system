using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }
        [Required]
        [StringLength(11,MinimumLength =11)]
        public string TcKimlik { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CustomerMail> Mails { get; set; }
        public List<CustomerPhone> PhoneNumbers { get; set; }
    }
}
