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
using Verleihsystem.Services.EventArgs;
using Verleihsystem.ViewModels;
using Verleihsystem.Windows;

namespace Verleihsystem.UserControls
{
    /// <summary>
    /// Interaction logic for HomeRibbon.xaml
    /// </summary>
    public partial class HomeRibbon : UserControl
    {
        public HomeRibbon()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            new EditAddCategory(new EditAddCategoryViewModel()).Show();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
