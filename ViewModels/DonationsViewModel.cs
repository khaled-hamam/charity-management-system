using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class DonationsViewModel : Screen
    {
        public ObservableCollection<DonationsCardViewModel> FilteredDonation { get; set; }
        private ObservableCollection<DonationsCardViewModel> _donations { get; set; }

        private IRepository<Donation> _repository;
        public DonationsViewModel()
        {
            _repository = new DonationRepo();
            _donations = new ObservableCollection<DonationsCardViewModel>();
            _donations = Mapper.toViewModel<Donation, DonationsCardViewModel>(
                DonationDataStore.instance.data as ObservableCollection<Donation>,
                    (employee) => new DonationsCardViewModel(employee));

            DonationDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) =>
            {
                FilteredDonation = Mapper.toViewModel<Donation, DonationsCardViewModel>(
                    obj as ObservableCollection<Donation>,
                    (employee) => new DonationsCardViewModel(employee)
                );
            });
            FilteredDonation = new ObservableCollection<DonationsCardViewModel>(_donations);
        }
    }
}
