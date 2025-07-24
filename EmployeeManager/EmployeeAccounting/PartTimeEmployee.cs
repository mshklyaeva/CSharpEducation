using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    /// <summary>
    /// Сотрудник с зарплатой, расчитываемой по часам.
    /// </summary>
    public class PartTimeEmployee : Employee
    {
        #region Поля и свойства
        /// <summary>
        /// Отработанные часы сотрудника.
        /// </summary>
        public int HoursWorked { get; set; }
        #endregion

        #region Базовый класс
        public override decimal CalculateSalary()
        {
            return BaseSalary * this.HoursWorked;
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">ID (уникальный номер).</param>
        /// <param name="name">Имя сотрудника.</param>
        /// <param name="baseSalary">Основная часть зарплаты (почасовая ставка).</param>
        public PartTimeEmployee(int id, string name, decimal baseSalary) : base(id, name, baseSalary)
        {
            this.HoursWorked = 1;
        }
        #endregion
    }
}
