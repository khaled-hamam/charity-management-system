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
        public Volunteer() { }
        public Volunteer(String SSN, String mobile, String Name, String addressLine1, String city, String governorate, int branchID, bool currentlyWorking) : base(SSN, mobile, Name, addressLine1, city, governorate)
        {
            this.currentlyWorking = currentlyWorking;
        }
    }
}
