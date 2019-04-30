using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using charity_management_system.DataStores;
using charity_management_system.Repositories;
using charity_management_system.ViewModels;
using charity_management_system.Models;

namespace charity_management_system.Views.Components
{
    /// <summary>
    /// Interaction logic for DonorCardView.xaml
    /// </summary>
    public partial class DonorCardView : UserControl
    {
        public DonorCardView()
        {
            InitializeComponent();
        }

        private void UpdateDonor_Click(object sender, RoutedEventArgs e)
        {
            DonorRepo DonorRepo = new DonorRepo();
            Donor donor = ((DonorCardViewModel)this.DataContext).donor;

            donor.name = nameTextBox.Text;
            donor.addressLine1 = line1TextBox.Text;
            donor.addressLine2 = line2TextBox.Text;
            donor.city = cityTextBox.Text;
            donor.governorate = governorateTextBox.Text;
            donor.mobile = mobileTextBox.Text;

            DonorRepo.update(donor);
        }

        private void DeleteDonor_Click(object sender, RoutedEventArgs e)
        {

            DonorRepo donorRepo = new DonorRepo();

            donorRepo.delete(((DonorCardViewModel)this.DataContext).donor);
            DonorDataStore.instance.data.Remove(((DonorCardViewModel)this.DataContext).donor);
        }
    }
}
