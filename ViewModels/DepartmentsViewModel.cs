using Caliburn.Micro;
using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Repositories;
using charity_management_system.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_management_system.ViewModels
{
    public class DepartmentsViewModel : Screen
    {

        public  List<Department> Departments { get; set; }
        private IRepository<Department> _repository;
        public DepartmentsViewModel()
        {
            _repository = new DepartmentRepo();
            Departments = new List<Department>();
            Departments = _repository.findAll();
        }
    }
}
