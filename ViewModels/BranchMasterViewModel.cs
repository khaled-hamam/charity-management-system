using Caliburn.Micro;
using charity_management_system.Models;
using charity_management_system.Repositories;
using System.Collections.Generic;
using System.Data;

namespace charity_management_system.ViewModels
{
    class BranchMasterViewModel : Screen
    {
        public List<Branch> Branches { get; set; }

        private BranchRepo _branchRepository;

        public BranchMasterViewModel()
        {
            _branchRepository = new BranchRepo();
            Branches = new List<Branch>(_branchRepository.findAll());
            _branchRepository.populate(Branches);
        }
    }
}
