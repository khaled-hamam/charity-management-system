using Caliburn.Micro;
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

        public EmployeeCardViewModel(PaidEmployee employee)
        {
            this.employee = employee;
        }
    }
}
