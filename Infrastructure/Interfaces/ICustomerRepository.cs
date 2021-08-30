using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);

        IReadOnlyList<Customer> ListAll();

        void Add(Customer entity);

        void Update(Customer entity);

        void Delete(Customer entity);
    }
}
