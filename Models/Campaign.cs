using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.Models {
    public class Campaign {
        public int id;
        public String name;
        public DateTime startDate;
        public DateTime endDate;
        public String description;
        public String goal;

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