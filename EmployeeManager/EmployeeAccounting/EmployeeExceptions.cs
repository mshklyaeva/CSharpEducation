using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    /// <summary>
    /// Исключение для системы учета сотрудников.
    /// </summary>
    public class EmployeeManagementException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public EmployeeManagementException(string message) : base(message) { }
    }

    /// <summary>
    /// Исключение в случае не нахождения сотрудника по ID.
    /// </summary>
    public class EmployeeNotFoundException : EmployeeManagementException
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="id">ID (уникальный номер сотрудника).</param>
        public EmployeeNotFoundException(int id)
            : base($"Сотрудник с ID {id} не найден") { }
    }
}
