using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeAccountingSystem system = new EmployeeAccountingSystem();

            string menuPoint = "0";

            while (menuPoint != "6")
            {
                Console.WriteLine("Выберите нужный пункт меню:\n" +
                "1. Добавить нового сотрудника\n" +
                "2. Обновить информацию о сотруднике\n" +
                "3. Получить информацию о сотруднике\n" +
                "4. Удалить сотрудника из списка\n" +
                "5. Расчитать зарплату сотрудника\n" +
                "6. Выход");

                menuPoint = Console.ReadLine();

                switch (menuPoint)
                {
                    case "1":
                        system.AddNewEmployee();
                        break;
                    case "2":
                        system.UpdateEmployee();
                        break;
                    case "3":
                        system.GetEmployeeInformation();
                        break;
                    case "4":
                        system.DeleteEmployee();
                        break;
                    case "5":
                        system.CalculateEmployeeSalary();
                        break;
                    case "6":
                        Console.WriteLine("Выход!");
                        break;
                    default:
                        Console.WriteLine("Введите корректный формат пункта меню");
                        break;

                }
            }
        }
    }
}
