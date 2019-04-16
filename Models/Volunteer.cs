using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    class Volunteer : Employee
    {
        public bool currentlyWorking;
        public Volunteer(int SSN, string Name, string addressLine1, string city, string governorate, int branchID, bool currentlyWorking) : base(SSN, Name, addressLine1, city, governorate, branchID)
        {
            this.currentlyWorking = currentlyWorking;
        }
    }
}
