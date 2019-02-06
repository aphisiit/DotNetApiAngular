using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrainDotNetCore.Models;
using OfficeOpenXml;

namespace TrainDotNetCore.Services
{
    public interface IEmployeeService
    {
        List<Employee> FindAllEmployee();
        Employee FindEmployeeById(int id);
        void SaveEmployee(Employee employee);
        void UpdateEmployee(int id,Employee employee);
        void deleteEmployee(int id);
        Dictionary<string, object> FindAllEmployeePageAndSize(int page, int size);
        string ExportEmployeeToExcel(string fileNames);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly DotNetCoreContext dotNetCoreContext;
        private readonly IHostingEnvironment _hostingEnvironment;
        public EmployeeService(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.dotNetCoreContext = new DotNetCoreContext();
        }

        public void deleteEmployee(int id)
        {
            Employee employee = this.dotNetCoreContext.Employee.Where(x => x.Id == id).FirstOrDefault();
            if(null == employee)
            {
                throw new Exception($"No data for employe Id = {id}");
            }
            this.dotNetCoreContext.Entry(employee).State = EntityState.Deleted;
            this.dotNetCoreContext.SaveChanges();
        }

        public string ExportEmployeeToExcel(string fileNames)
        {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"" + fileNames + ".xlsx";

            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {

                IList<Employee> customerList = this.dotNetCoreContext.Employee.ToList();

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employee");
                int totalRows = customerList.Count();

                worksheet.Cells[1, 1].Value = "Customer ID";                
                worksheet.Cells[1, 2].Value = "Customer Name";
                worksheet.Cells[1, 3].Value = "Customer Email";
                worksheet.Cells[1, 4].Value = "customer Country";
                int i = 0;
                for (int row = 2; row <= totalRows + 1; row++)
                {
                    worksheet.Cells[row, 1].Value = customerList[i].Id;
                    worksheet.Cells[row, 2].Value = customerList[i].FirstName;
                    worksheet.Cells[row, 3].Value = customerList[i].LastName;
                    worksheet.Cells[row, 4].Value = customerList[i].IpAddress;
                    i++;
                }

                package.Save();            

            }
            return fileName;
        }       

        public List<Employee> FindAllEmployee()
        {
            try
            {
                return dotNetCoreContext.Employee.ToList();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public Dictionary<string, object> FindAllEmployeePageAndSize(int page, int size)
        {
            size = null == size || size <= 0 ? 10 : size;
            int pageData = null == page || page <= 0 ? 0 : page * 10;
            
            try
            {
                int employeeSize = this.dotNetCoreContext.Employee.Count();
                List<Employee> employeeList = this.dotNetCoreContext.Employee.Skip(pageData).Take(size).ToList();
                Dictionary<string,object> dictionary = new Dictionary<string,object>();                
                dictionary.Add("page", page);
                dictionary.Add("pageData", pageData);
                dictionary.Add("dataSize", employeeSize);
                dictionary.Add("size", size);
                dictionary.Add("content", employeeList);
                return dictionary;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Employee FindEmployeeById(int id)
        {
            try
            {
                return this.dotNetCoreContext.Employee.Where(x => x.Id == id).FirstOrDefault();
            }catch(Exception e)
            {
                throw new Exception($"Can't find employee with id {id}");
            }
        }

        public void SaveEmployee(Employee employee)
        {
            try
            {
                this.dotNetCoreContext.Add(employee);
                this.dotNetCoreContext.SaveChanges();
            }catch(Exception e)
            {
                throw new Exception($"Can't save employee with data {employee}");
            }            
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    throw new Exception($"No id {id} in Employee Table");
                }
                this.dotNetCoreContext.Entry(employee).State = EntityState.Modified;
                this.dotNetCoreContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }           
        }
    }
}
