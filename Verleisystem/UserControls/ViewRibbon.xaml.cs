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

namespace Verleihsystem.UserControls
{
    /// <summary>
    /// Interaction logic for ViewRibbon.xaml
    /// </summary>
    public partial class ViewRibbon : UserControl
    {
        public event EventHandler<ViewRibbonSelectedEventArgs> SelectedEvent;

        public ViewRibbon()
        {
            InitializeComponent();
        }

        private void Rueckgaben_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kunden_Click(object sender, RoutedEventArgs e)
        {
            SelectedEvent?.Invoke(this, new ViewRibbonSelectedEventArgs { ViewContent = 1 });
        }

        private void Kategorien_Click(object sender, RoutedEventArgs e)
        {
            SelectedEvent?.Invoke(this, new ViewRibbonSelectedEventArgs { ViewContent = 2 });
        }

        private void Produkte_Click(object sender, RoutedEventArgs e)
        {
            SelectedEvent?.Invoke(this, new ViewRibbonSelectedEventArgs { ViewContent = 3 });
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
