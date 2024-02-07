using SElo8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SElo8.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();
        public Employee GetByName(string name);
        public void AddEmployee(Employee employee);
    }
}
