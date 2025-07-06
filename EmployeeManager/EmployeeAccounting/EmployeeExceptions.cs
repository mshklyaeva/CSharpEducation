using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public class EmployeeManagementException : Exception
    {
        public EmployeeManagementException(string message) : base(message) { }
    }

    public class EmployeeNotFoundException : EmployeeManagementException
    {
        public EmployeeNotFoundException(int id)
            : base($"Сотрудник с ID {id} не найден") { }
    }
}
