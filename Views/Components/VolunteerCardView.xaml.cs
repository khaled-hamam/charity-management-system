﻿using charity_management_system.DataStores;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using charity_management_system.ViewModels;
using charity_management_system.Repositories;

namespace charity_management_system.Views.Components
{
    /// <summary>
    /// Interaction logic for VolunteerCardView.xaml
    /// </summary>
    public partial class VolunteerCardView : UserControl
    {
        BranchRepo br = new BranchRepo();
        public VolunteerCardView()
        {
            InitializeComponent();
            foreach (Branch branch in br.findAll())
            {
                EmployeeBranchComboBox.Items.Add(branch.id);
            }
        }

        private void UpdateEmployeeClick(object sender, RoutedEventArgs e)
        {
            VolunteerRepo employeeRepo = new VolunteerRepo();
            Volunteer employee = ((VolunteerCardViewModel)this.DataContext).volunteer;

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
        
            employee.name = nameTextBox.Text;

            employeeRepo.update(((VolunteerCardViewModel)this.DataContext).volunteer);

        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        { 
            VolunteerRepo emp = new VolunteerRepo();

            emp.delete(((VolunteerCardViewModel)this.DataContext).volunteer);
            VolunteerDataStore.instance.data.Remove(((VolunteerCardViewModel)this.DataContext).volunteer);
        }
    }
}
