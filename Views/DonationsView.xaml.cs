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
    /// Interaction logic for DonationsView.xaml
    /// </summary>
    public partial class DonationsView : UserControl
    {
        DonorRepo donorRepo = new DonorRepo();
        CampaignRepo campaignRepo = new CampaignRepo();
        public DonationsView()
        {
            InitializeComponent();
            foreach (Donor donor in donorRepo.findAll())
            {
                DonorsComboBox.Items.Add(donor.id);
            }

            foreach (Campaign campaign in campaignRepo.findAll())
            {
                CampaignComboBox.Items.Add(campaign.id);
            }
        }
        private void addDonation(object sender, RoutedEventArgs e)
        {
            Donation donation = new Donation
            {
                donor = new Donor { id = int.Parse(DonorsComboBox.Text.ToString()) },
                campaign = new Campaign { id = int.Parse(CampaignComboBox.Text.ToString()) },
                date = DateTime.Now,
                type = DonationType.Text,
                value = float.Parse(DonationValue.Text),
            };
            DonationDataStore.instance.repository.save((Donation)donation);
            DonationDataStore.instance.data.Add((Donation)donation);
        }
    }
}
