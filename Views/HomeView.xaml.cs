using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Caliburn.Micro;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using charity_management_system.Utils;
using charity_management_system.ViewModels;

namespace charity_management_system.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            //DBManager db = DBManager.instance;
            InitializeComponent();
        }
    }
}
