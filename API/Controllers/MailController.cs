using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MailController : Controller
    {
        private readonly IGenericRepository<CustomerMail> _genericRepository;
        public readonly ICustomerRepository _customerRepository;

        public MailController(IGenericRepository<CustomerMail> genericRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _genericRepository = genericRepository;
        }

        //Mail
        [HttpGet]
        public IActionResult ListMail(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            return View(customer);
        }
        [HttpGet]
        public IActionResult CreateMail(int id)
        {
            CustomerMail mail = new CustomerMail { CustomerId = id };
            return View(mail);
        }
        [HttpPost]
        public IActionResult CreateMail(CustomerMail customerMail)
        {
            customerMail.Id = 0;
            _genericRepository.Add(customerMail);
            return RedirectToAction("ListMail", new { Id = customerMail.CustomerId });
        }
        [HttpGet]
        public IActionResult UpdateMail(int id)
        {
            CustomerMail customerMail = _genericRepository.GetById(id);
            return View(customerMail);
        }
        [HttpPost]
        public IActionResult UpdateMail(CustomerMail customerMail)
        {
            _genericRepository.Update(customerMail);
            return RedirectToAction("ListMail", new { Id = customerMail.CustomerId });
        }
    }
}
