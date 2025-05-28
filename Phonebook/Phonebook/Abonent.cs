using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation
{
    public class Abonent
    {
        public string Name { get; set; }
        public string Phone {  get; set; }

        public Abonent(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }
    }
}
