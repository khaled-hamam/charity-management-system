using System;

namespace charity_management_system.Models
{
    public class Employee
    {
        public int SSN { get; set; }
        public String name { get; set; }
        public String mobile { get; set; }
        public DateTime birthDate { get; set; }
        public char gender { get; set; }
        public String addressLine1 { get; set; }
        public String addressLine2 { get; set; }
        public String governorate { get; set; }
        public String city { get; set; }
        public DateTime startDate { get; set; }
        public String email { get; set; }
        public Branch branch { get; set; }
        public Employee() { }
        public Employee(int SSN, String mobile, String Name, String addressLine1, String city, String governorate)
        {
            this.SSN = SSN;
            this.name = Name;
            this.mobile = mobile;
            this.birthDate = System.DateTime.Today;
            this.addressLine1 = addressLine1;
            this.addressLine2 = "";
            this.city = city;
            this.governorate = governorate;
            this.startDate = System.DateTime.Today;
            this.email = "";

        }
    }
}
