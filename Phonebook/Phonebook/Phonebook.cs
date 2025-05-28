using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpEducation
{
    public class Phonebook
    {
        private static Phonebook instance;
        private string path = Path.GetFullPath("phonebook.txt");

        public List<Abonent> abonents = [];

        private Phonebook()
        {
            ReadPhonebook();
        }

        public static Phonebook getInstance()
        {
            if (instance == null)
                instance = new Phonebook();
            return instance;
        }

        private void ReadPhonebook()
        {
            if (File.Exists(path))
            {
                StreamReader sr = File.OpenText(path);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        Abonent abonent = new Abonent(parts[0], parts[1]);
                        abonents.Add(abonent);
                    }
                }
                sr.Close();
            }
            else
            {
                File.Create(path).Dispose();
            }
        }

        public void AddAbonent(Abonent abonent)
        {
            if (FindAbonentIndexByPhone(abonent.Phone) == -1)
            {
                abonents.Add(abonent);

                File.AppendAllText(path, $"{abonent.Name} {abonent.Phone}\n");
                Console.WriteLine("Абонент добавлен");
            }
            else
                Console.WriteLine("Такой абонент уже существует");
        }

        public void DeleteAbonent(string name)
        {
            int index = FindAbonentIndexByName(name);
            if (index != -1)
            {
                abonents.RemoveAt(index);

                File.WriteAllText(path, string.Empty);
                for (int i = 0; i < abonents.Count; i++)
                {
                    File.AppendAllText(path, $"{abonents[i].Name} {abonents[i].Phone}\n");
                }
                Console.WriteLine("Абонент удален");
            }
            else
                Console.WriteLine("Абонента не существует");

        }

        public void GetAbonentByName(string name)
        {
            int index = FindAbonentIndexByName(name);
            if (index != -1)
                Console.WriteLine($"{abonents[index].Name} {abonents[index].Phone}");
            else
                Console.WriteLine("Абонента с таким именем не существует");
        }

        public void GetAbonentByPhone(string phone)
        {
            int index = FindAbonentIndexByPhone(phone);
            if (index != -1)
                Console.WriteLine($"{abonents[index].Name} {abonents[index].Phone}");
            else
                Console.WriteLine("Абонента с таким номером телефона не существует");
        }

        private int FindAbonentIndexByName(string name)
        {
            for(int i=0; i<abonents.Count;i++)
            {
                if (abonents[i].Name == name) 
                    return i;
            }
            return -1;
        }
        private int FindAbonentIndexByPhone(string phone)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                if (abonents[i].Phone == phone) 
                    return i;
            }
            return -1;
        }

        public void GetAllAbonents()
        {
            if (abonents.Count == 0)
                Console.WriteLine("Список абонентов пуст");
            for (int i = 0; i < abonents.Count; i++)
            {
                Console.WriteLine($"{abonents[i].Name} {abonents[i].Phone}");
            }
        }
    }

}