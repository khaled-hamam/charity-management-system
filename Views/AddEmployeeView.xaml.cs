using charity_management_system.DataStores;
using charity_management_system.Models;
using charity_management_system.Utils;
using charity_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace charity_management_system.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : Window
    {
        public AddEmployeeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataStore.instance.data.Add(new PaidEmployee() { SSN = "Testing 2" } );
        }
    }
}
