using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    public class Branch
    {
        public int id { get; set; }
        public String addressLine1;
        public String addressLine2;
        public String governorate;
        public String city;
        public Branch() { }
        public Branch(String line1, String city, String governorate)
        {
            this.addressLine1 = line1;
            this.addressLine2= "";
            this.governorate = governorate;
            this.city = city;
        }
    }
}
