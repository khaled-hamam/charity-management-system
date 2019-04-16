using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using charity_management_system.Models;

namespace charity_management_system.Repositories
{
    class DonationRepo : IRepository<Donation>
    {
        public bool delete(Donation model)
        {
            throw new NotImplementedException();
        }

        public List<Donation> find(string column, string value)
        {
            throw new NotImplementedException();
        }

        public List<Donation> findAll()
        {
            throw new NotImplementedException();
        }

        public Donation findByID(string id)
        {
            throw new NotImplementedException();
        }

        public Donation save(Donation model)
        {
            throw new NotImplementedException();
        }

        public bool update(Donation newModel)
        {
            throw new NotImplementedException();
        }
    }
}
