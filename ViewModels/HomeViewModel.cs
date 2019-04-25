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
            ActivateItem(new EmployeesViewModel());
        }
        public void LoadEmployeesPage()
        {
            ActivateItem(new EmployeesViewModel());
        }
        public void LoadDepartmentsPage()
        {
            ActivateItem(new DepartmentsViewModel());
        }
        public void LoadDonorsPage()
        {
            ActivateItem(new DonorViewModel());
        }
    }
}
