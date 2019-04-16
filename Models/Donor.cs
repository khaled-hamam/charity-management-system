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
        public String donorGovernorate;
        public String donorCity;

        public Donor(int id, String name, String mobile, String address_line1, String city, String governorate)
        {
            donorID = id;
            donorName = name;
            donorMobile = mobile;
            donorLine1 = address_line1;
            donorCity = city;
            donorGovernorate = governorate;
        }
    }
}
