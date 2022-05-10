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
using Verleihsystem.Services;
using Verleihsystem.ViewModels;

namespace Verleisystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServiceProvider serviceProvider;
        private DbService dbservice;

        public MainWindow(MainWindowViewModel viewModel, DbService dbservice, IServiceProvider serviceProvider)
        {
            DataContext = viewModel;
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.dbservice = dbservice;
        }

        //Used for API testing
        private void File_OnClick(object sender, RoutedEventArgs e)
        {
            dbservice.GetAllEmployees();
            dbservice.GetAllProducts();
            dbservice.GetAllCustomers();
            dbservice.GetAllCategories();
        }
    }
}
