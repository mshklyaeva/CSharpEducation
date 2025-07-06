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
            EmployeeAccountingSistem sistem = new EmployeeAccountingSistem();

            string menuPoint = "0";

            while (menuPoint != "6")
            {
                //Console.Clear();

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
                        sistem.AddNewEmployee();
                        break;
                    case "2":
                        sistem.UpdateEmployee();
                        break;
                    case "3":
                        sistem.GetEmployeeInformation();
                        break;
                    case "4":
                        sistem.DeleteEmployee();
                        break;
                    case "5":
                        sistem.CalculateEmployeeSalary();
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
