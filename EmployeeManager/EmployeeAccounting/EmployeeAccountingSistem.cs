using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeAccounting
{
    public class EmployeeAccountingSistem
    {
        public EmployeeManager<Employee> repository;
        public EmployeeAccountingSistem() 
        {
            repository = EmployeeManager<Employee>.getInstance();
        }

        public void AddNewEmployee()
        {
            Employee newEmployee;

            Console.WriteLine("Введите имя сотрудника: ");
            string name = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Тип оплаты труда:\n" +
                "1. Сдельная оплата труда\n" +
                "2. Почасовая оплата труда\n" +
                "Введите номер пункта: ");

                string type = Console.ReadLine();

                if (type == "1")
                {
                    Console.WriteLine("Введите оклад сотрудника (например, 50450,5): ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                    {
                        Console.WriteLine("Неверный формат зарплаты. Попробуйте снова");
                        continue;
                    }

                    newEmployee = new FullTimeEmployee(repository.GetLastEmployeeId(), name, salary);
                    repository.Add(newEmployee);
                    break;

                }
                else if (type == "2")
                {
                    Console.WriteLine("Введите почасовую ставку сотрудника (например, 150,5): ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal hourlyRate))
                    {
                        Console.WriteLine("Неверный формат ставки. Попробуйте снова");
                        continue;
                    }

                    newEmployee = new PartTimeEmployee(repository.GetLastEmployeeId(), name, hourlyRate);
                    repository.Add(newEmployee);
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор типа оплаты труда. Попробуйте снова.");
                }
            }
            Console.WriteLine("Сотрудник успешно добавлен!");
        }

        public void PrintAllEmployees(out bool empty)
        {
            if (repository.GetAll().Count != 0)
            {
                empty = false;
                foreach (var employeeInList in repository.GetAll())
                {
                    Console.WriteLine(employeeInList.ToString());
                }
            }
            else
            {
                empty = true;
                Console.WriteLine("Список сотрудников пуст. Добавьте первого сотрудника.");
            }
        }

        public void UpdateEmployee()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Сотрудника с таким ID не существует");
                    return;
                }

                if (repository.TryGetById(id, out var employee))
                {
                    Console.WriteLine(employee.ToString());
                }
                else
                {
                    Console.WriteLine("Сотрудника с таким ID не существует");
                    return;
                }

                string newName;
                decimal newBaseSalary;

                Console.WriteLine("Хотите обновить имя сотрудника? y/n ");

                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("Введите новое имя сотрудника");
                    newName = Console.ReadLine();
                }
                else
                    newName = employee.Name;

                if (employee is PartTimeEmployee)
                {
                    Console.WriteLine("Хотите обновить почасовую ставку сотрудника? y/n ");

                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Введите новую почасовую ставку сотрудника");
                        if (!decimal.TryParse(Console.ReadLine(), out newBaseSalary))
                        {
                            Console.WriteLine("Неверный формат ставки.");
                            return;
                        }

                    }
                    else
                        newBaseSalary = employee.BaseSalary;
                }
                else
                {
                    Console.WriteLine("Хотите обновить оклад сотрудника? y/n ");

                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Введите новый оклад сотрудника");
                        if (!decimal.TryParse(Console.ReadLine(), out newBaseSalary))
                        {
                            Console.WriteLine("Неверный формат оклада.");
                            return;
                        }
                    }
                    else
                        newBaseSalary = employee.BaseSalary;
                }

                repository.Update(id, newName, newBaseSalary);
                Console.WriteLine("Информация успешно обновлена!");
            }
        }

        public void GetEmployeeInformation()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Неверный формат ID.");
                    return;
                }

                repository.TryPrintEmployeeInformationById(id);
            }
        }

        public void DeleteEmployee()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Неверный формат ID.");
                    return;
                }

                repository.TryDelete(id);
            }
        }

        public void CalculateEmployeeSalary()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Неверный формат ID.");
                    return; 
                }

                if (repository.TryGetById(id, out var employee))
                    Console.WriteLine(employee.ToString());
                else
                {
                    Console.WriteLine("Сотрудника с таким ID не существует");
                    return;
                }

                if (employee is PartTimeEmployee partTimeEmployee)
                {
                    Console.WriteLine("Введите количество отработанных часов: ");
                    if (!int.TryParse(Console.ReadLine(), out int hoursWorked))
                    {
                        Console.WriteLine("Неверный формат часов.");
                        return;
                    }
                    partTimeEmployee.HoursWorked = hoursWorked;
                }
                else if (employee is FullTimeEmployee fullTimeEmployee)
                {
                    Console.WriteLine("Введите бонус сотрудника в формате десятичной дроби (например, 0,1): ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal bonus))
                    {
                        Console.WriteLine("Неверный формат бонуса.");
                        return;
                    }
                    fullTimeEmployee.Bonus = bonus;
                }

                Console.WriteLine("Зарплата сотрудника: ");
                Console.WriteLine(employee.CalculateSalary());
            }
        }

    }
}
