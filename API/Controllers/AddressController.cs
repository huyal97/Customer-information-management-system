using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AddressController : Controller
    {
        private readonly IGenericRepository<Address> _genericRepository;
        public readonly ICustomerRepository _customerRepository;

        public AddressController(IGenericRepository<Address> genericRepository,ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _genericRepository = genericRepository;
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
            _genericRepository.Add(address);
            return RedirectToAction("ListAddress", new { Id = address.CustomerId });
        }

        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            Address address = _genericRepository.GetById(id);
            return View(address);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {
            _genericRepository.Update(address);
            return RedirectToAction("ListAddress", new { Id = address.CustomerId });
        }
        public IActionResult DeleteAddress(int id, int customerId)
        {
            Address customerAddress = _genericRepository.GetById(id);
            _genericRepository.Delete(customerAddress);
            return RedirectToAction("ListAddress", new { Id = customerId });
        }
    }
}
