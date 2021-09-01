using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }
        public Customer GetById(int id)
        {
            return _context.Set<Customer>().Include(r=>r.Addresses)
                .Include(r=>r.Mails)
                .Include(r=>r.PhoneNumbers)
                .FirstOrDefault(r=>r.Id == id);
        }       
        public IReadOnlyList<Customer> ListAll()
        {
            return _context.Set<Customer>()
                .Include(r => r.Addresses)
                .Include(r => r.PhoneNumbers)
                .Include(r => r.Mails)
                .ToList();
        }
        //Add
        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
            _context.SaveChanges();
        }
        public void Delete(Customer entity)
        {
            _context.Set<Customer>().Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Customer entity)
        {
            _context.Set<Customer>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
