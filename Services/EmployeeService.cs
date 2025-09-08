using Model;
using Repos.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService
    {
        private readonly IEmp _emp;
        public EmployeeService(IEmp emp)
        {
            _emp = emp;
        }
        public string AddEmployee(Employee emp)
        {
            string message = _emp.AddEmp(emp);
            return message;
        }
        public List<Employee> GetEmployees()
        {
            return _emp.GetEmployees();
        }
    }
}
