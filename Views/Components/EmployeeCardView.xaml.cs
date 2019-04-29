using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using charity_management_system.Repositories;
using charity_management_system.ViewModels;

namespace charity_management_system.Views.Components
{
    /// <summary>
    /// Interaction logic for EmployeeCardView.xaml
    /// </summary>
    public partial class EmployeeCardView : UserControl
    {
        public EmployeeCardView()
        {
            InitializeComponent();
        }
        private void UpdateEmployeeClick(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            PaidEmployeeRepo emp = new PaidEmployeeRepo();

            Console.WriteLine(((EmployeeCardViewModel)this.DataContext).employee.name);
            emp.delete(((EmployeeCardViewModel)this.DataContext).employee);

        }
    }
}
