using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;

namespace charity_management_system.ViewModels
{
    class CampaignViewModel : Screen
    {
        public ObservableCollection<CampaignCardViewModel> FilteredCampaigns { get; set; }
        private IRepository<Campaign> _repository;

        public CampaignViewModel()
        {
            _repository = new CampaignRepo();
            FilteredCampaigns = new ObservableCollection<CampaignCardViewModel>();

            FilteredCampaigns = Mapper.toViewModel<Campaign, CampaignCardViewModel>(
                CampaignDataStore.instance.data as ObservableCollection<Campaign>,
                    (campaign) => new CampaignCardViewModel(campaign));

            CampaignDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) =>
            {
                FilteredCampaigns = Mapper.toViewModel<Campaign, CampaignCardViewModel>(
                    obj as ObservableCollection<Campaign>,
                    (campaign) => new CampaignCardViewModel(campaign)
                );
            });
        }
    }
}
