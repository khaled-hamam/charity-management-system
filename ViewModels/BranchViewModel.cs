using Caliburn.Micro;
using System;
using System.Collections.Generic;
using charity_management_system.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using charity_management_system.Repositories;

namespace charity_management_system.ViewModels
{
    class BranchViewModel : Screen
    {
        public List<Branch> branches { get; set; }
        private IRepository<Branch> _repository;
        public BranchViewModel()
        {
            _repository = new BranchRepo();
            branches = new List<Branch>();
            branches = _repository.findAll();
        }
    }
}
