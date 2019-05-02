using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models {
    public class Campaign {
        public int id { get; set; }
        public String name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String description { get; set; }
        public String goal { get; set; }

        public Campaign() { }

        public Campaign (int id) {
            this.id = id;
        }

        public Campaign (String name, DateTime startDate, DateTime endDate) {
            this.name = name;
            this.startDate = startDate;
            this.endDate = endDate;
        }

    }
}