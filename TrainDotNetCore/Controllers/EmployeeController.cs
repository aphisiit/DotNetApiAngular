using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainDotNetCore.Models;
using TrainDotNetCore.Services;

namespace TrainDotNetCore.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employee)
        {
            this.employeeService = employee;
        }

        [HttpGet]
        public List<Employee> FindAllEmployee()
        {
            return this.employeeService.FindAllEmployee();
        }

        [HttpGet("FindAllEmployeePageAndSize")]
        public Dictionary<string,object> FindAllEmployeePageAndSize(int page,int size)
        {
            return this.employeeService.FindAllEmployeePageAndSize(page, size);
        }
    }
}
