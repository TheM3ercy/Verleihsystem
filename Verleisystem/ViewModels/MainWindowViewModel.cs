using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Verleihsystem.Services;
using Verleihsystem.UserControls;
using Verleihsystem.Windows;

namespace Verleihsystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private static IServiceProvider serviceProvider;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            MainWindowViewModel.serviceProvider = serviceProvider;
        }


        public ICommand OpenBorrowProductMenu = new RelayCommand<string>(_ =>
        {
            var window = serviceProvider.GetService(typeof(BorrowProduct)) as Window;
            window.Show();
        });

        public ICommand OpenEditAddCategoryWindow = new RelayCommand<string>(_ =>
        {
            var window = serviceProvider.GetService(typeof(EditAddCategory)) as Window;
            window.Show();
        });

        public ICommand OpenEditAddCustomerWindow = new RelayCommand<string>(_ =>
        {
            var window = serviceProvider.GetService(typeof(EditAddCustomer)) as Window;
            window.Show();
        });

        public ICommand OpenEditAddProductWindow = new RelayCommand<string>(_ =>
        {
            var window = serviceProvider.GetService(typeof(EditAddProduct)) as Window;
            window.Show();
        });
    }
}
