using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;
using charity_management_system.Views;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace charity_management_system.ViewModels
{
    class DonorViewModel : Screen
    {
        public ObservableCollection<DonorCardViewModel> FilteredDonors { get; set; }
        private IRepository<Donor> _repository;

        public DonorViewModel()
        {
            _repository = new DonorRepo();
            FilteredDonors = new ObservableCollection<DonorCardViewModel>();

            FilteredDonors = Mapper.toViewModel<Donor, DonorCardViewModel>(
                DonorDataStore.instance.data as ObservableCollection<Donor>,
                    (donor) => new DonorCardViewModel(donor));

            DonorDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) =>
            {
                FilteredDonors = Mapper.toViewModel<Donor, DonorCardViewModel>(
                    obj as ObservableCollection<Donor>,
                    (donor) => new DonorCardViewModel(donor)
                );
            });
        }
    }
}
