using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using charity_management_system.Models;

namespace charity_management_system.Models
{
    class PaidEmployee : Employee
    {
        float salary;
        Department department;

        public PaidEmployee(int SSN, string Name, string addressLine1, string city, string governorate, int branchID, float salary) : base(SSN, Name, addressLine1, city, governorate, branchID)
        {
            this.salary = salary;
        }
    }
}
