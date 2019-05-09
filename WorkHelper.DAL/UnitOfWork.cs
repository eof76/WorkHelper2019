using System;
using WorkHelper.DAL.Entities;
using WorkHelper.DAL.Interfaces;
using WorkHelper.DAL.Repositories;

namespace WorkHelper.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext dbContext;
        private bool disposed;

        // Список репозиториев
        private IRepository<Employee> employeeRepository;

        public UnitOfWork(string connectionString)
        {
            dbContext = new EFDbContext(connectionString);
            disposed = false;
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(dbContext);
                }
                return employeeRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
