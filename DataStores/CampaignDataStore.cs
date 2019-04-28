using System;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.DataStores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.DataStores
{
    class CampaignDataStore : BaseDataStore<Campaign>
    {
        private static CampaignDataStore _instance;
        public static CampaignDataStore instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CampaignDataStore();
                }
                return _instance;
            }
        }

        private CampaignDataStore() : base(new CampaignRepo())
        {
        }
    }
}
