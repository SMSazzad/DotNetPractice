using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryAppPractice1
{
    class Employee
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }

        public Salary Salary { get; set; }
    }
}
