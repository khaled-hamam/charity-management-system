using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace charity_management_system.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        DepartmentRepo dr = new DepartmentRepo();
        BranchRepo br = new BranchRepo();
        public EmployeesView()
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
        private void addEmployee(object sender, RoutedEventArgs e)
        {
            char empGender;
            if (employeeGender.Text.ToString() == "Male")
                empGender = 'M';
            else
                empGender = 'F';
            Employee employee = new PaidEmployee()
            {
                SSN = SSNTextBox.Text,
                name = nameTextBox.Text,
                mobile = mobileTextBox.Text,
                birthDate = birthdayBox.SelectedDate.Value.Date,
                gender = empGender,
                addressLine1 = line1TextBox.Text,
                addressLine2 = line2TextBox.Text,
                city = cityTextBox.Text,
                governorate = governorateTextBox.Text,
                email = emailTextBox.Text,
                branch = new Branch { id = int.Parse(EmployeeBranchComboBox.Text.ToString()) },
                salary = int.Parse(salaryTextBox.Text),
                department = new Department(EmployeeDepartmentComboBox.Text.ToString()),
            };
            EmployeeDataStore.instance.repository.save((PaidEmployee)employee);
            EmployeeDataStore.instance.data.Add((PaidEmployee)employee);
        }

    }
}
