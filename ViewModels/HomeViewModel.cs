using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class HomeViewModel : Conductor<object>
    {
       
        public HomeViewModel()
        {

        }
        public void LoadEmployeePage()
        {
            ActivateItem(new EmployeesViewModel());
        }
    }
}
