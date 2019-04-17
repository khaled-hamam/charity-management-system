using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    public class Branch
    {
        public int branchID;
        public String branchLine1;
        public String branchLine2;
        public String branchGovernorate;
        public String branchCity;

        public Branch(int id, String line1, String city, String governorate)
        {
            this.branchID = id;
            this.branchLine1 = line1;
            this.branchLine2 = "";
            this.branchGovernorate = governorate;
            this.branchCity = city;
        }
    }
}
