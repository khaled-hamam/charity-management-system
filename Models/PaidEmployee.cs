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

        public PaidEmployee(int SSN, string Name, string addressLine1, string addressLine2, string Governorate, int branchID, float salary) : base(SSN, Name, addressLine1, addressLine2, Governorate, branchID)
        {
            this.salary = salary;
        }
    }
}
