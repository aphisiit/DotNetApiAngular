using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.Data;
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

        private readonly ILogger _logger;

        public EmployeeController(IEmployeeService employee, ILogger<EmployeeController> logger)
        {
            this.employeeService = employee;
            _logger = logger;
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

        [HttpGet("GetEmployeeFromExcel")]
        public IActionResult GetEmployeeFromExcel()
        {
            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot", "Aphisit_Namracha.xlsx");
            var dtContent = GetDataTableFromExcel(path);

            string name = dtContent.Rows[0]["customer Name"].ToString();
            this._logger.LogInformation($"name : {name}");
            return Ok(dtContent);
        }

        private DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    this._logger.LogInformation($"Column  : {firstRowCell.Start.Column}");
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                        this._logger.LogInformation($"{cell.Text}");
                    }
                }
                return tbl;
            }
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
