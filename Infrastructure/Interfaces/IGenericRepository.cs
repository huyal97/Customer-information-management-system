using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T>
    {
        public T GetById(int id);
        public IReadOnlyList<T> ListAll();
        public void Add(T entity);
        public void Update(T entity);
    }
}
