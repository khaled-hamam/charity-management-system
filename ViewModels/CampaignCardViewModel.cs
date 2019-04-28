using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;


namespace charity_management_system.ViewModels
{
    class CampaignCardViewModel : Screen
    {
        public Campaign campaign { get; set; }

        public CampaignCardViewModel(Campaign campaign)
        {
            this.campaign = campaign;
        }
    }
}
