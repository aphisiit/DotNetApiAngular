using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainDotNetCore.Models;

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
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly DotNetCoreContext dotNetCoreContext;
        public EmployeeService()
        {
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
