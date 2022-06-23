using API.Models;
using API.Models.Models;
using API.Services.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EntityDBContext _context;

        public EmployeeService(EntityDBContext context)
        {
            _context = context;
        }
        public async void DeleteEmployee(Guid Id)
        {
            var emp =  _context.Employee.FirstOrDefault(e => e.Id == Id);
            _context.Employee.Remove(emp);

        }

        public async Task<Employee> UpdateEmployee(EmployeeDto emp)
        {
            var Emp = _context.Employee.FirstOrDefault(e => e.Id == emp.Id);
            var EmpTax=_context.EmployeeTax.FirstOrDefault(e => e.EmployeeId == emp.Id);
            
            if (Emp != null)
            {
                Emp.Name = emp.Name;
                Emp.Email = emp.Email;
                Emp.Salary = emp.Salary;
                Emp.Mobile = emp.Mobile;
            }

            if(EmpTax != null)
            {
                EmpTax.Tax = emp.TaxRate;
                EmpTax.NetSalary= emp.NetSalary;
            }

            await _context.SaveChangesAsync();

            return Emp;    
        }

        public async Task<EmployeeDto> GetEmployeeById(Guid Id)
        {
            var employee =await (from emp in _context.Employee
                            join empT in _context.EmployeeTax
                            on emp.Id equals empT.EmployeeId
                            select new EmployeeDto
                            {
                                Id = emp.Id,
                                Name = emp.Name,
                                Salary = emp.Salary,
                                Email = emp.Email,
                                Mobile = emp.Mobile,
                                NetSalary = empT.NetSalary,
                                TaxRate = empT.Tax,
                            }).FirstOrDefaultAsync(e => e.Id == Id);

            return employee;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
           var employees= _context.Employee.Select(e => new EmployeeDto { 
            
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Email = e.Email,
                Mobile=e.Mobile,

            });

            return await employees.ToListAsync();
        }

        public async Task<Employee> AddEmployee(EmployeeDto emp)
        {

            var newEmployee = await _context.Employee.AddAsync(new Employee()
            {

                Name = emp.Name,
                Email = emp.Email,
                Mobile = emp.Mobile,
                Salary = emp.Salary,
            });

            await _context.EmployeeTax.AddAsync(new EmployeeTax() { 
            
                Tax=emp.TaxRate,
                NetSalary=emp.NetSalary,
                EmployeeId=newEmployee.Entity.Id

            });

            await _context.SaveChangesAsync();
            return newEmployee.Entity;
        }
    }
}
