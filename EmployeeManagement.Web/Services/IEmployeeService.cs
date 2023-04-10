using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<HttpResponseMessage> UpdateEmployee(Employee updatedEmployee);
        Task<HttpResponseMessage> CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
    }
}
