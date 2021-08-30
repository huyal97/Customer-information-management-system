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

            return View();
        }
    }
}
