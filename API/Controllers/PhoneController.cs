using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IGenericRepository<CustomerPhone> _genericRepository;
        public readonly ICustomerRepository _customerRepository;

        public PhoneController(IGenericRepository<CustomerPhone> genericRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _genericRepository = genericRepository;
        }

        //Mail
        [HttpGet]
        public IActionResult ListPhone(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            return View(customer);
        }
        [HttpGet]
        public IActionResult CreatePhone(int id)
        {
            CustomerMail mail = new CustomerMail { CustomerId = id };
            return View(mail);
        }
        [HttpPost]
        public IActionResult CreatePhone(CustomerPhone customerPhone)
        {
            customerPhone.Id = 0;
            _genericRepository.Add(customerPhone);
            return RedirectToAction("ListPhone", new { Id = customerPhone.CustomerId });
        }
        [HttpGet]
        public IActionResult UpdatePhone(int id)
        {
            CustomerPhone customerPhone = _genericRepository.GetById(id);
            return View(customerPhone);
        }
        [HttpPost]
        public IActionResult UpdatePhone(CustomerPhone phone)
        {
            _genericRepository.Update(phone);
            return RedirectToAction("ListPhone", new { Id = phone.CustomerId });
        }
    }
}
