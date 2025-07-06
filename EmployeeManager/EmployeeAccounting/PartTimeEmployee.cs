using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public class PartTimeEmployee : Employee
    {

        public int HoursWorked { get; set; }

        public PartTimeEmployee(int id, string name, decimal baseSalary) : base(id, name, baseSalary)
        {
            this.HoursWorked = 1; 
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary * HoursWorked;
        }
    }
}
