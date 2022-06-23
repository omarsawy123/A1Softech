using API.Services.Dto;
using API.Services.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace A1Softech.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {

            try
            {
                var employees =await _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }


        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployee([FromRoute]Guid Id)
        {

            try
            {
                var employee = await _employeeService.GetEmployeeById(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]EmployeeDto employee)
        {

            try
            {
                var emp = await _employeeService.AddEmployee(employee);
                return Ok(emp);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }


        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody]EmployeeDto newEmployee)
        {

            try
            {
                var employee = await _employeeService.UpdateEmployee(newEmployee);
                return Ok(employee);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }


        }

        [HttpDelete("{Id}")]
        public void DeleteEmployee(Guid Id)
        {
            try
            {
                _employeeService.DeleteEmployee(Id);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}













