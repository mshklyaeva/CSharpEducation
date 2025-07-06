using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccounting
{
    public interface IEmployeeManager<T>
    {

        public void Add(T employee);

        public void Update(int id, string name, decimal BaseSalary);

        public void TryDelete(int id);

        public T GetById(int id);
    }
}
