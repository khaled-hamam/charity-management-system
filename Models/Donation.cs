using System;

namespace charity_management_system.Models {
    public class Donation {
        public Donor donor;
        public Campaign campaign;
        public DateTime date;
        public String type;
        public float value;

        public Donation () { }

        public Donation (DateTime date, String type) {
            this.date = date;
            this.type = type;
        }
    }
}