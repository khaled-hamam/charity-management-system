using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    class Donor
    {
        public int donorID;
        public String donorName;
        public String donorMobile;
        public String donorLine1;
        public String donorLine2;
        public String donorGovernrate;
        public String donorCity;

        public Donor()
        {
            donorID = 0;
            donorName = "";
            donorMobile = "";
            donorLine1 = "";
            donorLine2 = "";
            donorGovernrate = "";
            donorCity = "";
        }
    }
}
