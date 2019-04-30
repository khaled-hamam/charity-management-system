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
        private ObservableCollection<CampaignCardViewModel> _Campaigns { get; set; }

        private IRepository<Campaign> _repository;
        public String SearchValue { get; set; }

        public CampaignViewModel()
        {
            SearchValue = "";
            _repository = new CampaignRepo();
            _Campaigns = new ObservableCollection<CampaignCardViewModel>();
            _Campaigns = Mapper.toViewModel<Campaign, CampaignCardViewModel>(
                CampaignDataStore.instance.data as ObservableCollection<Campaign>,
                    (campaign) => new CampaignCardViewModel(campaign));

            DonorDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) =>
            {
                FilteredCampaigns = Mapper.toViewModel<Campaign, CampaignCardViewModel>(
                    obj as ObservableCollection<Campaign>,
                    (campaign) => new CampaignCardViewModel(campaign)
                );
            });


            this.PropertyChanged += CampaignViewModel_PropertyChanged;

            FilteredCampaigns = new ObservableCollection<CampaignCardViewModel>(_Campaigns);


        }
        private void CampaignViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchValue" && SearchValue.Length > 0)
            {
                Campaign p = CampaignDataStore.instance.repository.findByID(SearchValue);
                FilteredCampaigns.Clear();
                if (p != null)
                {

                    var s = new CampaignCardViewModel(p);
                    FilteredCampaigns.Add(s);

                }
            }
            else if (e.PropertyName == "SearchValue")
            {
                FilteredCampaigns = _Campaigns;
            }
        }

    }
}
