using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    /// <summary>
    /// Менеджер для управления данными сотрудника.
    /// </summary>
    /// <typeparam name="T">Сотрудник на полной ставке или с почасовой оплатой.</typeparam>
    public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
    {
        #region Поля и свойства
        /// <summary>
        /// Экземпляр менеджера для управления данными сотрудника.
        /// </summary>
        private static EmployeeManager<T> instance;

        /// <summary>
        /// Список сотрудников.
        /// </summary>
        private List<T> employees { get; }
        #endregion

        #region Методы
        /// <summary>
        /// Получить экземпляр менеджера для управления данными сотрудника.
        /// </summary>
        /// <returns>Экземпляр менеджера для управления данными сотрудника.</returns>
        public static EmployeeManager<T> getInstance()
        {
            if (instance == null)
                instance = new EmployeeManager<T>();

            return instance;
        }

        /// <summary>
        /// Получить сотрудника по ID.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        /// <param name="employee">Сотрудник, если он найден, иначе - null.</param>
        /// <returns>True, если сотрудник найден, иначе - False.</returns>
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

        /// <summary>
        /// Вывести на экран информацию о сотруднике.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        public void TryPrintEmployeeInformationById(int id)
        {
            try
            {
                var employee = GetById(id);

                Console.WriteLine("Информация о сотруднике:");
                Console.WriteLine(employee.ToString() + $" | фиксированная часть зарплаты: {employee.BaseSalary}");
            }
            catch
            {
                Console.WriteLine("Сотрудника с таким ID не существует");
            }
        }

        /// <summary>
        /// Получить ID для нового сотрудника.
        /// </summary>
        /// <returns>ID нового сотрудника.</returns>
        public int GetNewEmployeeId()
        {
            if (employees.Count == 0)
                return 1;

            return employees[employees.Count - 1].Id + 1;
        }
        #endregion

        #region <IEmployeeManager>
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

        /// <summary>
        /// Найти сотрудника по ID.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        /// <returns>Сотрудник с введенным ID.</returns>
        /// <exception cref="EmployeeNotFoundException">Сотрудник с введенным ID не найден.</exception>
        public T GetById(int id)
        {
            foreach(T employee in employees)
            {
                if(employee.Id == id)
                    return employee;
            }
            throw new EmployeeNotFoundException(id);
        }

        public List<T> GetAll()
        {
            return employees;
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор.
        /// </summary>
        private EmployeeManager()
        {
            employees = new List<T>();
        }
        #endregion
    }
}
