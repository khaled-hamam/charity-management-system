using Caliburn.Micro;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class DonationsCardViewModel : Screen
    {
        public Donation donation { get; set; }
        public String donorID {get; set;}
        public String campaignID { get; set; }
        public DonationsCardViewModel(Donation donation)
        {
            this.donation = donation;
            donorID = donation.donor.id.ToString();
            campaignID = donation.campaign.id.ToString();
        }
    }
}
