using Caliburn.Micro;
using System;
using System.Collections.Generic;
using charity_management_system.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using charity_management_system.Repositories;
using System.Data;

namespace charity_management_system.ViewModels
{
    class BranchViewModel : Screen
    {
        public DataView branches { get; set; }
        private BranchRepo _repository;
        public BranchViewModel()
        {
            _repository = new BranchRepo();
            branches = new DataView();
            branches = _repository.dataSet.Tables[0].DefaultView;
        }
        public void save()
        {
            foreach (DataRow dr in branches.Table.Rows)
            {
                Console.WriteLine(dr["id"]);
            }
            // Console.WriteLine("here");
            _repository.saveData(branches.Table);
        }
    }
}
