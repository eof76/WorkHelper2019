using System;
using System.Collections.Generic;

namespace WorkHelper.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void CreateOrUpdate(T entity);
        void Delete(int id);
    }
}
