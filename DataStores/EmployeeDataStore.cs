using charity_management_system.Models;
using charity_management_system.Repositories;

namespace charity_management_system.DataStores
{
    public class EmployeeDataStore : BaseDataStore<PaidEmployee>
    {
        private static EmployeeDataStore _instance;
        public static EmployeeDataStore instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeDataStore();
                }
                return _instance;
            }
        }

        private EmployeeDataStore() : base(new PaidEmployeeRepo())
        {
        }
    }
}
