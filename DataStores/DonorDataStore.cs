using charity_management_system.Models;
using charity_management_system.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.DataStores
{
    class DonorDataStore :BaseDataStore<Donor>
    {
        private static DonorDataStore _instance;
        public static DonorDataStore instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DonorDataStore();
                }
                return _instance;
            }
        }

        private DonorDataStore() : base(new DonorRepo())
        {
        }
    }
}
