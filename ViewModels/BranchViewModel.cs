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
        public DataView FilteredBranches { get; set; }
        private BranchRepo _repository;

        public string SearchValue { get; set; }
        public BranchViewModel()
        {
            _repository = new BranchRepo();
            branches = new DataView();
            branches.Table = _repository.dataSet.Tables[0].DefaultView.Table.Copy();
            this.PropertyChanged += BranchesViewModel_PropertyChanged;
            FilteredBranches = new DataView();
            FilteredBranches.Table = branches.Table.Copy();
        }
        public void save()
        {
              branches.Table = FilteredBranches.Table.Copy();
            _repository.saveData(FilteredBranches.Table);
        }


        private void BranchesViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchValue" && SearchValue.Length > 0)
            {
                FilteredBranches.Table.Rows.Clear();
                string s = "city = '" + SearchValue + "'";
                DataRow[] dr = branches.Table.Select(s);
                if (dr.Length != 0)
                {
                    foreach(DataRow d in dr)
                    {
                        FilteredBranches.Table.ImportRow(d);
                    }
                    Console.WriteLine(FilteredBranches.Table.Rows[0]["city"]);
                }


            }
            else if (e.PropertyName == "SearchValue")
            {
                FilteredBranches.Table = branches.Table.Copy();
            }
        }
    }
}
