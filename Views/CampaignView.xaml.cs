
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using System;
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
    /// Interaction logic for CampaignView.xaml
    /// </summary>
    public partial class CampaignView : UserControl
    {
        public CampaignView()
        {
            InitializeComponent();
        }

        private void addCampaign(object sender, RoutedEventArgs e)
        {
            CampaignRepo campaign = new CampaignRepo();
            Campaign newCampaign = new Campaign() { name = nameTextBox.Text, startDate = CampaignStartDatePicker.SelectedDate.Value.Date, endDate = CampaignEndDatePicker.SelectedDate.Value.Date, description = CampaignDescriptionTextBox.Text, goal = CampaignGoalTextBox.Text };
            campaign.save(newCampaign);
            CampaignDataStore.instance.data.Add(newCampaign);
        }
    }
}
