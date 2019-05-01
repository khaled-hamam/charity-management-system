using Caliburn.Micro;
using charity_management_system.Repositories;
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
        public void LoadPaidEmployeesPage()
        {
            ActivateItem(new EmployeesViewModel());
        }
        public void LoadVolunteersPage()
        {
            ActivateItem(new VolunteerViewModel());
        }
        public void LoadDepartmentsPage()
        {
            ActivateItem(new DepartmentsViewModel());
        }
        public void LoadDonorsPage()
        {
            ActivateItem(new DonorViewModel());
        }

        public void LoadBranchMasterPage()
        {
            ActivateItem(new BranchMasterViewModel());
        }

        public void LoadBranchPage()
        {
            ActivateItem(new BranchViewModel());
        }

        public void LoadCampaignsPage()
        {
            ActivateItem(new CampaignViewModel());
        }
        public void LoadDonationsPage()
        {
            ActivateItem(new DonationsViewModel());
        }
    }
}
