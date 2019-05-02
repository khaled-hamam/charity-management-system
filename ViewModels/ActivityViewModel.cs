using Caliburn.Micro;
using charity_management_system.Models;
using charity_management_system.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    class ActivityViewModel : Screen
    {
        public List<Activity> Activities { get; set; }

        public List<int> CampaignList { get; set; }
        public List<String> VolunteerList { get; set; }
        public String Description { get; set; }

        public ActivityViewModel()
        {
            var repo = new ActivityRepo();
            Activities = new List<Activity>(repo.findAll());
        }

        public void AddButton()
        {
            Console.WriteLine("Here");
        }
    }
}
