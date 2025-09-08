using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repos
{
    public interface IEmp
    {
        string AddEmp(Employee emp);
        string EditEmp(Employee emp);
        List<Employee> GetEmployees();
        string RemoveEmp(int id);
    }
}
