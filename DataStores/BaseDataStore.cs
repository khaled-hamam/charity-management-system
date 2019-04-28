using charity_management_system.Repositories;
using System.Collections.ObjectModel;

namespace charity_management_system.DataStores
{
    public abstract class BaseDataStore<T>
    {
        private IRepository<T> _repository;
        public IRepository<T> repository { get { return _repository; } set { _repository = value; } }
        public ObservableCollection<T> data;

        protected BaseDataStore(IRepository<T> repository)
        {
            this.repository = repository;
            this.data = new ObservableCollection<T>(_repository.findAll());
        }
    }
}
