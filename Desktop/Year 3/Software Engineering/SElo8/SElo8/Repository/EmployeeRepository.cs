using SElo8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        public EmployeeRepository() 
        { 
            employees = new List<Employee>();
        }
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public Employee GetByName(string name)
        {
            return employees.FirstOrDefault(e => e.Name.Equals(name));
        }
    }
}
