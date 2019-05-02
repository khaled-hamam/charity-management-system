using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models
{
    public class Activity
    {
        public string description { get; set; }
        public Volunteer volunteer { get; set; }
        public Campaign campaign { get; set; }
    }
}
