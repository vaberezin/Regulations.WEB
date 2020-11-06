using System;
using System.Collections.Generic;
using System.Text;

namespace Regulations.DAL.Interfaces
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllItems();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
