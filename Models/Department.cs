using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    class Department
    {
        String name;
        public String Name { get { return this.name; } private set { this.name = value; } }

        public Department()
        {
            this.Name = "";
        }
        public Department(String name)
        {
            this.Name = name;
        }
    }
}
