using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;
using charity_management_system.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace charity_management_system.ViewModels
{
    class DonorViewModel : Screen
    {
        public ObservableCollection<DonorCardViewModel> FilteredDonors { get; set; }
        private ObservableCollection<DonorCardViewModel> _Donors { get; set; }

        private IRepository<Donor> _repository;
        public String SearchValue { get; set; }

        public DonorViewModel()
        {
            SearchValue = "";
            _repository = new DonorRepo();
            _Donors = new ObservableCollection<DonorCardViewModel>();
            _Donors = Mapper.toViewModel<Donor, DonorCardViewModel>(
                DonorDataStore.instance.data as ObservableCollection<Donor>,
                    (donor) => new DonorCardViewModel(donor));

            DonorDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) =>
            {
                FilteredDonors = Mapper.toViewModel<Donor, DonorCardViewModel>(
                    obj as ObservableCollection<Donor>,
                    (donor) => new DonorCardViewModel(donor)
                );
            });

       
            this.PropertyChanged += DonorViewModel_PropertyChanged;

            FilteredDonors = new ObservableCollection<DonorCardViewModel>(_Donors);

         
        }
        private void DonorViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchValue" && SearchValue.Length > 0)
            {
                Donor p = DonorDataStore.instance.repository.findByID(SearchValue);
                FilteredDonors.Clear();
                if (p != null)
                {
                   
                    var s = new DonorCardViewModel(p);
                    FilteredDonors.Add(s);
                    
                }
            }
            else if (e.PropertyName == "SearchValue")
            {
                FilteredDonors = _Donors;
            }
        }
    
    }
}
