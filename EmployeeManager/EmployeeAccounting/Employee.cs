using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    /// <summary>
    /// Сотрудник основной.
    /// </summary>
    public abstract class Employee
    {
        #region Поля и свойства
        /// <summary>
        /// Уникальный номер сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Основная часть зарплаты сотрудника (месячная или поасовая ставка).
        /// </summary>
        public decimal BaseSalary { get; set; }
        #endregion

        #region Методы
        /// <summary>
        /// Вычислить зарплату сотрудника.
        /// </summary>
        /// <returns>Зарплата сотрудника: 
        /// зарплата с учетом бонуса, если сотрудник с фиксированной зарплатой,
        /// зарплата за отработанное количество часов, если зарплата сотрудника рассчитывается по часам.</returns>
        public abstract decimal CalculateSalary();
        #endregion

        #region Базовый класс
        /// <summary>
        /// Преобразовать данные о сотрудниках в строку.
        /// </summary>
        /// <returns>Строка с данными о сотруднике (ID и имя).</returns>
        public override string ToString()
        {
            return $"ID: {this.Id} | Имя: {this.Name}";
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">ID (уникальный номер сотрудника).</param>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="baseSalary">Основная часть зарплаты сотрудника.</param>
        public Employee(int id, string name, decimal baseSalary)
        {
            this.Id = id;
            this.Name = name;
            this.BaseSalary = baseSalary;
        }
        #endregion
    }
}
