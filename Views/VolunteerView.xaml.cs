using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
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
    /// Interaction logic for VolunteerView.xaml
    /// </summary>
    public partial class VolunteerView : UserControl
    {
        BranchRepo br = new BranchRepo();
        public VolunteerView()
        {
            InitializeComponent();
            foreach (Branch branch in br.findAll())
            {
                EmployeeBranchComboBox.Items.Add(branch.id);
            }
        }
        private void addEmployee(object sender, RoutedEventArgs e)
        {
            char empGender;
            if (employeeGender.Text.ToString() == "Male")
                empGender = 'M';
            else
                empGender = 'F';
            Employee employee = new Volunteer()
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
                currentlyWorking = false,
            };
            VolunteerDataStore.instance.repository.save((Volunteer)employee);
            VolunteerDataStore.instance.data.Add((Volunteer)employee);
        }
    }
}
