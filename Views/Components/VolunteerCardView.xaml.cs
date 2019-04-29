using charity_management_system.DataStores;
using charity_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using charity_management_system.ViewModels;
using charity_management_system.Repositories;

namespace charity_management_system.Views.Components
{
    /// <summary>
    /// Interaction logic for VolunteerCardView.xaml
    /// </summary>
    public partial class VolunteerCardView : UserControl
    {
        public VolunteerCardView()
        {
            InitializeComponent();
        }

        private void UpdateEmployeeClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        { 
            VolunteerRepo emp = new VolunteerRepo();

            emp.delete(((VolunteerCardViewModel)this.DataContext).volunteer);
        }
    }
}
