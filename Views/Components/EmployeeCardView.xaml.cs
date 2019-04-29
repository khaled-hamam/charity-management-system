using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.ViewModels;

namespace charity_management_system.Views.Components
{
    /// <summary>
    /// Interaction logic for EmployeeCardView.xaml
    /// </summary>
    public partial class EmployeeCardView : UserControl
    {
        DepartmentRepo dr = new DepartmentRepo();
        BranchRepo br = new BranchRepo();
        public EmployeeCardView()
        {
            InitializeComponent();
            foreach (Branch branch in br.findAll())
            {
                EmployeeBranchComboBox.Items.Add(branch.id);
            }
            foreach (Department dep in dr.findAll())
            {
                EmployeeDepartmentComboBox.Items.Add(dep.name);
            }
            
        }
        private void UpdateEmployeeClick(object sender, RoutedEventArgs e)
        {
            PaidEmployeeRepo employeeRepo = new PaidEmployeeRepo();
            PaidEmployee employee = ((EmployeeCardViewModel)this.DataContext).employee;

            char empGender;
            if (employeeGender.Text.ToString() == "Male")
                empGender = 'M';
            else
                empGender = 'F';

            employee.name = nameTextBox.Text;
            employee.mobile = mobileTextBox.Text;
            employee.email = emailTextBox.Text;
            employee.birthDate = birthdayBox.SelectedDate.Value.Date;
            employee.gender = empGender;
            employee.addressLine1 = line1TextBox.Text;
            employee.addressLine2 = line2TextBox.Text;
            employee.city = cityTextBox.Text;
            employee.governorate = governorateTextBox.Text;
            employee.branch = new Branch { id = int.Parse(EmployeeBranchComboBox.Text.ToString()) };
            employee.salary = int.Parse(salaryTextBox.Text);
            employee.department = new Department(EmployeeDepartmentComboBox.Text.ToString());
            employee.name = nameTextBox.Text;

            employeeRepo.update(((EmployeeCardViewModel)this.DataContext).employee);
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            PaidEmployeeRepo employeeRepo = new PaidEmployeeRepo();

            employeeRepo.delete(((EmployeeCardViewModel)this.DataContext).employee);
            EmployeeDataStore.instance.data.Remove(((EmployeeCardViewModel)this.DataContext).employee);
        }
    }
}
