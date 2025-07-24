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
    /// <summary>
    /// Система учета сотрудников.
    /// </summary>
    public class EmployeeAccountingSystem
    {
        #region Константы
        /// <summary>
        /// Выбор пользователя, если он хочет ответить "Yes" - да
        /// </summary>
        public const string Y = "y";

        /// <summary>
        /// Выбор пользователем первого пункта меню
        /// </summary>
        public const string Type1 = "1";

        /// <summary>
        /// Выбор пользователем второго пункта меню
        /// </summary>
        public const string Type2 = "2";
        #endregion

        #region Поля и свойства
        /// <summary>
        /// Список всех добавленных сотрудников.
        /// </summary>
        private EmployeeManager<Employee> repository;
        #endregion

        #region Методы
        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
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

                if (type == Type1)
                {
                    Console.WriteLine("Введите оклад сотрудника (например, 50450,5): ");
                    var isDecimal = decimal.TryParse(Console.ReadLine(), out decimal salary);

                    if (!isDecimal)
                    {
                        Console.WriteLine("Неверный формат зарплаты. Попробуйте снова");
                        continue;
                    }

                    newEmployee = new FullTimeEmployee(repository.GetNewEmployeeId(), name, salary);
                    repository.Add(newEmployee);
                    break;

                }
                else if (type == Type2)
                {
                    Console.WriteLine("Введите почасовую ставку сотрудника (например, 150,5): ");
                    var isDecimal = decimal.TryParse(Console.ReadLine(), out decimal hourlyRate);

                    if (!isDecimal)
                    {
                        Console.WriteLine("Неверный формат ставки. Попробуйте снова");
                        continue;
                    }

                    newEmployee = new PartTimeEmployee(repository.GetNewEmployeeId(), name, hourlyRate);
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

        /// <summary>
        /// Вывести на экран информацию обо всех сотрудниках.
        /// </summary>
        /// <param name="empty">True, если список сотрудников пуст, иначе - False.</param>
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

        /// <summary>
        /// Обновить информацию о сотруднике.
        /// </summary>
        public void UpdateEmployee()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");
                var isInt = int.TryParse(Console.ReadLine(), out int id);

                if (!isInt)
                {
                    Console.WriteLine("Сотрудника с таким ID не существует");
                    return;
                }

                var isEmployeeFound = repository.TryGetById(id, out var employee);

                if (isEmployeeFound)
                {
                    Console.WriteLine(employee.ToString());
                }
                else
                {
                    Console.WriteLine("Сотрудника с таким ID не существует");
                    return;
                }

                string newName;

                Console.WriteLine("Хотите обновить имя сотрудника? y/n ");
                var choice = Console.ReadLine();

                if (choice == Y)
                {
                    Console.WriteLine("Введите новое имя сотрудника");
                    newName = Console.ReadLine();
                }
                else
                {
                    newName = employee.Name;
                }

                decimal newBaseSalary;

                if (employee is PartTimeEmployee)
                {
                    Console.WriteLine("Хотите обновить почасовую ставку сотрудника? y/n ");
                    choice = Console.ReadLine();

                    if (choice == Y)
                    {
                        Console.WriteLine("Введите новую почасовую ставку сотрудника");
                        var isDecimal = decimal.TryParse(Console.ReadLine(), out newBaseSalary);

                        if (!isDecimal)
                        {
                            Console.WriteLine("Неверный формат ставки.");
                            return;
                        }
                    }
                    else
                    {
                        newBaseSalary = employee.BaseSalary;
                    }
                }
                else
                {
                    Console.WriteLine("Хотите обновить оклад сотрудника? y/n ");
                    choice = Console.ReadLine();

                    if (choice == Y)
                    {
                        Console.WriteLine("Введите новый оклад сотрудника");
                        var isDecimal = decimal.TryParse(Console.ReadLine(), out newBaseSalary);

                        if (!isDecimal)
                        {
                            Console.WriteLine("Неверный формат оклада.");
                            return;
                        }
                    }
                    else
                    {
                        newBaseSalary = employee.BaseSalary;
                    }
                }

                repository.Update(id, newName, newBaseSalary);
                Console.WriteLine("Информация успешно обновлена!");
            }
        }

        /// <summary>
        /// Получить информацию о сотруднике.
        /// </summary>
        public void GetEmployeeInformation()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");
                var isInt = int.TryParse(Console.ReadLine(), out int id);

                if (!isInt)
                {
                    Console.WriteLine("Неверный формат ID.");
                    return;
                }

                repository.TryPrintEmployeeInformationById(id);
            }
        }

        /// <summary>
        /// Удалить сотрудника их списка.
        /// </summary>
        public void DeleteEmployee()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");
                var isInt = int.TryParse(Console.ReadLine(), out int id);

                if (!isInt)
                {
                    Console.WriteLine("Неверный формат ID.");
                    return;
                }

                repository.TryDelete(id);
            }
        }

        /// <summary>
        /// Вычислить зарплату сотрудника.
        /// </summary>
        public void CalculateEmployeeSalary()
        {
            PrintAllEmployees(out bool empty);

            if (!empty)
            {
                Console.WriteLine("Введите ID нужного сотрудника из списка: ");
                var isInt = int.TryParse(Console.ReadLine(), out int id);

                if (!isInt)
                {
                    Console.WriteLine("Неверный формат ID.");
                    return; 
                }

                var isEmployeeFound = repository.TryGetById(id, out var employee);

                if (isEmployeeFound)
                {
                    Console.WriteLine(employee.ToString());
                }
                else
                {
                    Console.WriteLine("Сотрудника с таким ID не существует");
                    return;
                }

                if (employee is PartTimeEmployee partTimeEmployee)
                {
                    Console.WriteLine("Введите количество отработанных часов: ");
                    isInt = int.TryParse(Console.ReadLine(), out int hoursWorked);

                    if (!isInt)
                    {
                        Console.WriteLine("Неверный формат часов.");
                        return;
                    }

                    partTimeEmployee.HoursWorked = hoursWorked;
                }
                else if (employee is FullTimeEmployee fullTimeEmployee)
                {
                    Console.WriteLine("Введите бонус сотрудника в формате десятичной дроби (например, 0,1): ");
                    var isDecimal = decimal.TryParse(Console.ReadLine(), out decimal bonus);

                    if (!isDecimal)
                    {
                        Console.WriteLine("Неверный формат бонуса.");
                        return;
                    }

                    fullTimeEmployee.Bonus = bonus;
                }

                Console.WriteLine($"Зарплата сотрудника: {employee.CalculateSalary()}");
            }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Контруктор.
        /// </summary>
        public EmployeeAccountingSystem()
        {
            repository = EmployeeManager<Employee>.getInstance();
        }
        #endregion
    }
}
