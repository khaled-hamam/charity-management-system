using charity_management_system.Models;
using charity_management_system.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.DataStores
{
    public class DonationDataStore : BaseDataStore<Donation>
    {
        private static DonationDataStore _instance;
        public static DonationDataStore instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DonationDataStore();
                }
                return _instance;
            }
        }

        private DonationDataStore() : base(new DonationRepo())
        {
        }
    }
}
