using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
    {
        private static EmployeeManager<T> instance;
        private EmployeeManager() 
        {
            employees = new List<T>();
        }

        public static EmployeeManager<T> getInstance()
        {
            if (instance == null)
                instance = new EmployeeManager<T>();
            return instance;
        }

        private List<T> employees { get; }

        public void Add(T employee)
        {
            employees.Add(employee);
        }

        public void Update(int id, string name, decimal baseSalary)
        {
            foreach (T employee in employees)
            {
                if(employee.Id == id)
                {
                    employee.Name = name;
                    employee.BaseSalary = baseSalary;
                }
                return;
            }
        }

        public T GetById(int id)
        {
            foreach(T employee in employees)
            {
                if(employee.Id == id)
                    return employee;
            }
            throw new EmployeeNotFoundException(id);
        }

        public bool TryGetById(int id, out T employee)
        {
            try
            {
                employee = GetById(id);
            }
            catch
            {
                employee = null;
                return false;
            }
            return true;
        }

        public void TryPrintEmployeeInformationById(int id)
        {
            try
            {
                var employee = GetById(id);

                Console.WriteLine("Информация о сотруднике:");
                Console.WriteLine(employee.ToString() + $"| фиксированная часть зарплаты: {employee.BaseSalary}");
            }
            catch
            {
                Console.WriteLine("Сотрудника с таким ID не существует");
            }
        }

        public List<T> GetAll()
        {
            return employees;
        }

        public int GetLastEmployeeId()
        {
            if (employees.Count == 0) return 1;

            return employees[employees.Count - 1].Id + 1;
        }

        public void TryDelete(int id)
        {
            try
            {
                var employee = GetById(id);
                employees.Remove(employee);
                Console.WriteLine("Сотрудник успешно удален!");
            }
            catch
            {
                Console.WriteLine("Сотрудника с таким ID не существует");
            }
        }
    }
}
