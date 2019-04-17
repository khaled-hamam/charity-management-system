using Caliburn.Micro;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class EmployeesViewModel : Screen
    {
        private BindableCollection<Employee> _employees = new BindableCollection<Employee>();
        public BindableCollection<Employee> Employees { get; set; }

        public EmployeesViewModel()
        {
            _employees.Add(new Employee
            {
                employeeName = "Karim"
            });
            Employees = new BindableCollection<Employee>(_employees); 
        }

        
    }
}
