using System;

namespace charity_management_system.Models {
    public class Donation {
        public Donor donor { get; set; }
        public Campaign campaign { get; set; }
        public DateTime date { get; set; }
        public String type { get; set; }
        public float value { get; set; }

        public Donation () { }

        public Donation (DateTime date, String type) {
            this.date = date;
            this.type = type;
        }
    }
}