﻿using System;

namespace charity_management_system.Models
{
    class Employee
    {
        public int SSN;
        public String employeeName;
        public String employeeMobile;
        public DateTime employeeBirthDate;
        public char gender;
        public String employeeLine1;
        public String employeeLine2;
        public String employeeGovernorate;
        public String employeeCity;
        public DateTime employeeStartDate;
        public String employeeEmail;
        public Branch branch;

        public Employee(int SSN, String Name, String addressLine1, String addressLine2, String Governorate, int branchID)
        {
            this.SSN = SSN;
            this.employeeName = Name;
            this.employeeMobile = "";
            this.employeeBirthDate = System.DateTime.Today;
            this.employeeLine1 = addressLine1;
            this.employeeLine2 = addressLine2;
            this.employeeCity = "";
            this.employeeGovernorate = Governorate;
            this.employeeStartDate = System.DateTime.Today;
            this.employeeEmail = "";
            this.branch.branchID = branchID;

        }
    }
}