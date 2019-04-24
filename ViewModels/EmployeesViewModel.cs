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
    public class EmployeesViewModel : Screen
    {
        public ObservableCollection<EmployeeCardViewModel> FilteredEmployees { get; set; }
        private IRepository<PaidEmployee> _repository;

        public EmployeesViewModel()
        {
            _repository = new PaidEmployeeRepo();
            FilteredEmployees = new ObservableCollection<EmployeeCardViewModel>();

            EmployeeDataStore.instance.data.CollectionChanged += new NotifyCollectionChangedEventHandler((obj, e) => {
                FilteredEmployees = Mapper.toViewModel<PaidEmployee, EmployeeCardViewModel>(
                    obj as ObservableCollection<PaidEmployee>, 
                    (employee) => new EmployeeCardViewModel(employee)
                );
            });
        }

        public void openAddEmployee()
        {
            AddEmployeeView addEmployee = new AddEmployeeView();
            addEmployee.Show();
        }
    }
}
