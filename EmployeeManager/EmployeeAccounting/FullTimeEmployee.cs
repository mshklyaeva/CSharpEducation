using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public class FullTimeEmployee : Employee
    {
        public decimal Bonus { get; set; }
        public FullTimeEmployee(int id, string name, decimal baseSalary) 
            : base(id, name, baseSalary)
        {
            this.Bonus = 0.1m;
        }
        public override decimal CalculateSalary()
        {
            return BaseSalary * (1+Bonus);
        }
    }
}
