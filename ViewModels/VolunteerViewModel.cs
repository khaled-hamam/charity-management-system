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
    public class VolunteerViewModel : Screen
    {
        public ObservableCollection<VolunteerCardViewModel> FilteredEmployees { get; set; }
        private ObservableCollection<VolunteerCardViewModel> _employees { get; set; }

        public String SearchValue { get; set; }
        private IRepository<Volunteer> _repository;

        public VolunteerViewModel()
        {
            _repository = new VolunteerRepo();
            _employees = new ObservableCollection<VolunteerCardViewModel>();
            _employees = Mapper.toViewModel<Volunteer, VolunteerCardViewModel>(
                VolunteerDataStore.instance.data as ObservableCollection<Volunteer>,
                    (employee) => new VolunteerCardViewModel(employee));

            VolunteerDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) =>
            {
                FilteredEmployees = Mapper.toViewModel<Volunteer, VolunteerCardViewModel>(
                    obj as ObservableCollection<Volunteer>,
                    (employee) => new VolunteerCardViewModel(employee)
                );
            });
            this.PropertyChanged += VolunteerViewModel_PropertyChanged;
            FilteredEmployees = new ObservableCollection<VolunteerCardViewModel>(_employees);
        }
        private void VolunteerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchValue" && SearchValue.Length > 0)
            {
                Volunteer v = VolunteerDataStore.instance.repository.findByID(SearchValue);
                FilteredEmployees.Clear();
                if (v != null)
                {
                    var s = new VolunteerCardViewModel(v);
                    FilteredEmployees.Add(s);
                }
            }
            else if (e.PropertyName == "SearchValue")
            {
                FilteredEmployees = _employees;
            }
        }
    }
}
