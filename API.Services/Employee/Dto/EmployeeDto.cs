using API.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Services.Dto
{
    public class EmployeeDto : Employee
    {
        public float NetSalary { get; set; }
        public float TaxRate { get; set; }
    }
}
