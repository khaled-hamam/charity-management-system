using Caliburn.Micro;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;
using charity_management_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class EmployeesViewModel : Screen
    {
        private BindableCollection<EmployeeCardViewModel> _employees = new BindableCollection<EmployeeCardViewModel>();
        public BindableCollection<EmployeeCardViewModel> FilteredEmployees { get; set; }

        public EmployeesViewModel()
        {
            _employees = new BindableCollection<EmployeeCardViewModel>();
            _employees.Add(
                new EmployeeCardViewModel
                {
                    Role = "paid"
                }
                );

            FilteredEmployees = new BindableCollection<EmployeeCardViewModel>(_employees);
        }
        public void openAddEmployee()
        {
            AddEmployeeView addEmployee = new AddEmployeeView();
            addEmployee.Show();
        }
    }
}
