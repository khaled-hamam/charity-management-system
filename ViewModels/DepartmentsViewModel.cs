using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class DepartmentsViewModel : Screen
    {
        public DataView Departments { get; set; }
        public DataView FilteredDepartments { get; set; }

        private DepartmentRepo _repository;
         public string SearchValue { get; set; }
        public DepartmentsViewModel()
        {
            SearchValue = "";
            _repository = new DepartmentRepo();
            Departments = new DataView();
            Departments.Table = _repository.dataSet.Tables[0].DefaultView.Table.Copy();
            this.PropertyChanged += DepartmentsViewModel_PropertyChanged;
            FilteredDepartments = new DataView();
            FilteredDepartments.Table = Departments.Table.Copy();
        }

        public void save()
        {
            Departments.Table = FilteredDepartments.Table.Copy();
            _repository.saveData(Departments.Table);
        }

        private void DepartmentsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
       {
            if (e.PropertyName == "SearchValue" && SearchValue.Length > 0)
            {
                FilteredDepartments.Table.Rows.Clear();
                string s = "name = '" +SearchValue+"'";
                DataRow[] dr = Departments.Table.Select(s);
                if (dr.Length!=0)
                {
                    FilteredDepartments.Table.ImportRow(dr[0]);
                }
               

            }
            else if (e.PropertyName == "SearchValue")
            {
                FilteredDepartments.Table = Departments.Table.Copy();
            }
        }
    }
}