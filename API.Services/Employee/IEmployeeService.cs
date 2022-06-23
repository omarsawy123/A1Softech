using API.Models.Models;
using API.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Employees
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeDto>> GetEmployees();
        public Task<EmployeeDto> GetEmployeeById(Guid Id);
        public Task<Employee> AddEmployee(EmployeeDto emp);
        public Task<Employee> UpdateEmployee(EmployeeDto emp);
        public void DeleteEmployee(Guid Id);

    }
}
