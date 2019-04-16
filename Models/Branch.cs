using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    class Branch
    {
        public int branchID;
        public String branchLine1;
        public String branchLine2;
        public String branchGovernrate;
        public String branchCity;

        public Branch()
        {
            branchID = 0;
            branchLine1 = "";
            branchLine2 = "";
            branchGovernrate = "";
            branchCity = "";
        }
    }
}
