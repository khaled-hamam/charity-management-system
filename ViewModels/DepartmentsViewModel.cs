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
        public  DataView Departments { get; set; }
        private DepartmentRepo _repository;
        public DepartmentsViewModel()
        {
            _repository = new DepartmentRepo();
            Departments = new DataView();
            Departments = _repository.dataSet.Tables[0].DefaultView;
        }

        public void save()
        {
            _repository.saveData(Departments.Table);
        }
    }
}
