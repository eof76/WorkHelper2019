using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WorkHelper.DAL.Entities;
using WorkHelper.DAL.Interfaces;

namespace WorkHelper.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private EFDbContext dbContext;

        public EmployeeRepository(EFDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateOrUpdate(Employee entity)
        {
            if (entity == null) throw new NullReferenceException();
            if (entity.Id == 0)
            {
                dbContext.Employees.Add(entity);
            }
            else
            {
                dbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var entity = dbContext.Employees.Find(id);
            if (entity != null)
            {
                dbContext.Employees.Remove(entity);
            }
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate) => dbContext.Employees.Where(predicate).ToList();

        public IEnumerable<Employee> GetAll() => dbContext.Employees.ToList();

        public Employee GetById(int id) => dbContext.Employees.Find(id);
    }
}
