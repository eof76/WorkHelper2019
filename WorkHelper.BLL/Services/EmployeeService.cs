using System.Collections.Generic;
using System.Linq;
using WorkHelper.BLL.DTO;
using WorkHelper.BLL.Interfaces;
using WorkHelper.DAL.Entities;
using WorkHelper.DAL.Interfaces;

namespace WorkHelper.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork database;

        public EmployeeService(IUnitOfWork database)
        {
            this.database = database;
        }

        public void CreateOrUpdateEmployee(EmployeeDTO employeeDTO)
        {
            database.Employees.CreateOrUpdate(EmployeeDTOToEmployee(employeeDTO));
            database.Save();
        }

        public void DeleteEmployee(int id)
        {
            database.Employees.Delete(id);
            database.Save();
        }

        public void Dispose()
        {
            database.Dispose();
        }

        public EmployeeDTO GetEmployee(int id) =>
            EmployeeToEmployeeDTO(database.Employees.GetById(id));

        public IEnumerable<EmployeeDTO> GetEmployees() =>
            database.Employees.GetAll().OrderBy(e => e.LastName).ThenBy(e => e.FirstName).Select(e => EmployeeToEmployeeDTO(e));

        private EmployeeDTO EmployeeToEmployeeDTO(Employee employee)
        {
            if (employee == null) return null;
            return new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName
            };
        }

        private Employee EmployeeDTOToEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null) return null;
            return new Employee()
            {
                Id = employeeDTO.Id,
                FirstName = employeeDTO.FirstName,
                MiddleName = employeeDTO.MiddleName,
                LastName = employeeDTO.LastName
            };
        }
    }
}
