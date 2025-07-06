using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(int id, string name, decimal baseSalary)
        {
            Id = id;
            Name = name;
            BaseSalary = baseSalary;
        }

        public override string ToString()
        {
            return $"ID: {this.Id} | Имя: {this.Name}";
        }

        public abstract decimal CalculateSalary();
    }
}
