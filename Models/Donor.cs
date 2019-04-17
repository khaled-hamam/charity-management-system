using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    class Donor
    {
        public int id;
        public String name;
        public String mobile;
        public String addressLine1;
        public String addressLine2;
        public String governorate;
        public String city;

        public Donor(int id, String name, String mobile, String address_line1, String city, String governorate)
        {
            this.id = id;
            this.name = name;
            this.mobile = mobile;
            this.addressLine1 = address_line1;
            this.city = city;
            this.governorate = governorate;
        }
    }
}
