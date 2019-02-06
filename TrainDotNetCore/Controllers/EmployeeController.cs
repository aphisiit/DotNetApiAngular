using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet("ExportData")]
        public async Task<IActionResult> ExportData(string fileName)
        {
            string fileRealName = this.employeeService.ExportEmployeeToExcel(fileName);
            if (fileRealName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", fileRealName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }    
}
