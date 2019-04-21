using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models {
    public class Donor {
        public int id;
        public String name;
        public String mobile;
        public String addressLine1;
        public String addressLine2;
        public String governorate;
        public String city;

        public Donor (String name, String mobile, String address_line1, String city, String governorate) {
            this.name = name;
            this.mobile = mobile;
            this.addressLine1 = address_line1;
            this.city = city;
            this.governorate = governorate;
        }

        public Donor (int id) {
            this.id = id;
        }
    }
}