using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    /// <summary>
    /// Сотрудник с фиксированной зарплатой.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        #region Поля и свойства
        /// <summary>
        /// Часть от зарплаты, которая будет бонусом.
        /// </summary>
        public decimal Bonus { get; set; }
        #endregion

        #region Базовый класс
        public override decimal CalculateSalary()
        {
            return BaseSalary * (1 + this.Bonus);
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="baseSalary">Основная часть зарплаты сотрудника.</param>
        public FullTimeEmployee(int id, string name, decimal baseSalary)
            : base(id, name, baseSalary)
        {
            this.Bonus = 0.1m;
        }
        #endregion
    }
}
