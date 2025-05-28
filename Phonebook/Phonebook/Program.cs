using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Phonebook phonebook = Phonebook.getInstance();

            string name, phone, userChoice = "0";
            Abonent abonent;

            while(userChoice != "6")
            {
                Console.WriteLine("Выберите пункт меню:\n" +
                "1. Добавить абонента в телефонную книгу\n" +
                "2. Удалить абонента из телефонной книги\n" +
                "3. Найти имя абонента по номеру телефона\n" +
                "4. Найти номер телефона абонента по имени\n" +
                "5. Получить список всех абонентов телефонной книги\n" +
                "6. Выход");

                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Write("Введите имя абонента: ");
                        name = Console.ReadLine();
                        Console.Write("Введите номер телефона абонента: ");
                        phone = Console.ReadLine();
                        abonent = new Abonent(name, phone);
                        phonebook.AddAbonent(abonent);
                        break;
                    case "2":
                        Console.Write("Введите имя абонента: ");
                        name = Console.ReadLine();
                        phonebook.DeleteAbonent(name);
                        break;
                    case "3":
                        Console.Write("Введите номер телефона абонента: ");
                        phone = Console.ReadLine();
                        phonebook.GetAbonentByPhone(phone);
                        break;
                    case "4":
                        Console.Write("Введите имя абонента: ");
                        name = Console.ReadLine();
                        phonebook.GetAbonentByName(name);
                        break;
                    case "5":
                        phonebook.GetAllAbonents();
                        break;
                    case "6":
                        Console.WriteLine("Выход");
                        break;
                    default:
                        Console.WriteLine("Выберите существующий пункт меню");
                        break;
                }
            }
            
        }
    }
}
