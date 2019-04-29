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


namespace charity_management_system.Views
{
    /// <summary>
    /// Interaction logic for CampaignCardView.xaml
    /// </summary>
    public partial class CampaignCardView : UserControl
    {
        public CampaignCardView()
        {
            InitializeComponent();
        }

        private void DeleteCampaign_Click(object sender, RoutedEventArgs e)
        {
            CampaignRepo campaignRepo = new CampaignRepo();

            campaignRepo.delete(((CampaignCardViewModel)this.DataContext).campaign);
            CampaignDataStore.instance.data.Remove(((CampaignCardViewModel)this.DataContext).campaign);
        }

        private void UpdateCampaign_Click(object sender, RoutedEventArgs e)
        {
            CampaignRepo campaignRepo = new CampaignRepo();
            Campaign campaign = ((CampaignCardViewModel)this.DataContext).campaign;

            campaign.name = nameTextBox.Text;
            campaign.description = descriptionTextBox.Text;
            campaign.goal = goalTextBox.Text;
            campaign.startDate = startDate.SelectedDate.Value.Date;
            campaign.endDate = endDate.SelectedDate.Value.Date;
        }
    }
}
