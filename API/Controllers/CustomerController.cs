using API.Dtos;
using API.Helper;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerMapper _customerMapper;
        public CustomerController(ICustomerRepository customerRepository,ICustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListCustomer()
        {
            IReadOnlyList<Customer> customers = _customerRepository.ListAll();
            return View(customers);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            Customer customer = _customerMapper.CustomerDtoToCustomer(customerDto);

            _customerRepository.Add(customer);

            return RedirectToAction("ListCustomer");
        }
        public IActionResult ListAddress(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            return View(customer);
        }
        [HttpGet]
        public IActionResult CreateAddress(int id)
        {
            Address address = new Address { CustomerId = id };
            return View(address);
        }
        [HttpPost]
        public IActionResult CreateAddress(Address address)
        {
            address.Id = 0;
            _customerRepository.AddAddress(address);
            return RedirectToAction("ListAddress", new { Id = address.CustomerId});
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
            _customerRepository.AddMail(customerMail);
            return RedirectToAction("ListMail", new { Id = customerMail.CustomerId });
        }



        //[HttpPost]
        //public IActionResult CreateAddress(int id)
        //{
        //    Customer customer = _customerRepository.GetById(id);

        //    return View(customer);
        //}
    }
}
