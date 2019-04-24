using Caliburn.Micro;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class DonorCardViewModel : Screen
    {
        public Donor donor { get; set; }

        public DonorCardViewModel(Donor donor)
        {
            this.donor = donor;
        }
    }
}
