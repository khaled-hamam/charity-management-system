using Caliburn.Micro;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class VolunteerCardViewModel : Screen
    {
        public Volunteer volunteer { get; set; }
        public String Role { get; set; }
        public VolunteerCardViewModel(Volunteer volunteer)
        {
            this.Role = "Volunteer";
            this.volunteer = volunteer;
        }
    }
}
