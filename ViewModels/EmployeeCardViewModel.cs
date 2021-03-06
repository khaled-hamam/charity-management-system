﻿using Caliburn.Micro;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class EmployeeCardViewModel : Screen
    {
        public PaidEmployee employee { get; set; }
        public String Role { get; set; }
        public EmployeeCardViewModel(PaidEmployee employee)
        {
            this.Role = "Paid Employee";
            this.employee = employee;
        }
    }
}
