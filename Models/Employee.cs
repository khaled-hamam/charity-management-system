using System;

namespace charity_management_system.Models
{
    public class Employee
    {
        public int SSN;
        public String name;
        public String mobile;
        public DateTime birthDate;
        public char gender;
        public String addressLine1;
        public String addressLine2;
        public String governorate;
        public String city;
        public DateTime startDate;
        public String email;
        public Branch branch;
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
