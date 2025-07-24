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
    /// <typeparam name="T"></typeparam>
    public interface IEmployeeManager<T>
    {
        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
        /// <param name="employee">Сотрудник.</param>
        public void Add(T employee);

        /// <summary>
        /// Обновить информацию о сотруднике.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        /// <param name="name">Обновленное имя сотрудника.</param>
        /// <param name="BaseSalary">Обновленная основная часть зарплаты сотрдуника.</param>
        public void Update(int id, string name, decimal BaseSalary);

        /// <summary>
        /// Удалить сотрудника с введенным ID.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        public void TryDelete(int id);

        /// <summary>
        /// Получить сотрудника по ID.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        /// <returns>Сотрудник с введенным ID.</returns>
        public T GetById(int id);

        /// <summary>
        /// Получить список всех сотрудников.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        public List<T> GetAll();
    }
}
