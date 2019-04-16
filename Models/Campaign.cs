using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    class Campaign
    {
        public int campaignID;
        public String campaignName;
        public DateTime startDate;
        public DateTime endDate;
        public String campaignDescription;
        public String campaignGoal;

        Campaign(int id, String name, DateTime startDate , DateTime endDate)
        {
            this.campaignID = id;
            this.campaignName = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }   
    }
}
