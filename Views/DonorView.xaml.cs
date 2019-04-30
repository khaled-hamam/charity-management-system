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
    /// Interaction logic for DonorView.xaml
    /// </summary>
    public partial class DonorView : UserControl
    {
        public DonorView()
        {
            InitializeComponent();
        }
        private void addDonor(object sender, RoutedEventArgs e)
        {
            DonorRepo donor = new DonorRepo();
            Donor newDonor = new Donor() { id = (int)DateTime.Now.Ticks, name = nameTextBox.Text, addressLine1 = DonorAddress1TextBox.Text, addressLine2 = DonorAddress2TextBox.Text, city = DonorCityTextBox.Text, governorate = DonorgovernorateTextBox.Text, mobile = DonorMobileTextBox.Text };
            donor.save(newDonor);
            DonorDataStore.instance.data.Add(newDonor);
        }
    }
}
