using charity_management_system.Models;
using charity_management_system.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.DataStores
{
    public class VolunteerDataStore : BaseDataStore<Volunteer>
    {
        private static VolunteerDataStore _instance;
        public static VolunteerDataStore instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VolunteerDataStore();
                }
                return _instance;
            }
        }

        private VolunteerDataStore() : base(new VolunteerRepo())
        {
        }
    }
}
