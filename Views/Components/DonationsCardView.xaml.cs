using charity_management_system.Models;
using charity_management_system.Repositories;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace charity_management_system.Views.Components
{
    /// <summary>
    /// Interaction logic for DonationsCardView.xaml
    /// </summary>
    public partial class DonationsCardView : UserControl
    {
        DonorRepo donorRepo = new DonorRepo();
        CampaignRepo campaignRepo = new CampaignRepo();
        public DonationsCardView()
        {
            InitializeComponent();
        }
    }
}
