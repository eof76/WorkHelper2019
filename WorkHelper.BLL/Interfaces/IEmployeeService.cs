using System.Collections.Generic;
using WorkHelper.BLL.DTO;

namespace WorkHelper.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int id);
        void CreateOrUpdateEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
        void Dispose();
    }
}
