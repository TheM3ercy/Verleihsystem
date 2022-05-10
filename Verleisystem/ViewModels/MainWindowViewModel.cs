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
            FillViews();
        }

        public void FillViews()
        {
            UserControls = new();
            var dbservice = serviceProvider.GetService(typeof(DbService)) as DbService;
            dbservice.GetAllProducts().ForEach(x => UserControls.Add(new ProductUserControl
            {
                ProductName = x.Name,
                CategoryName = x.Kategorie,
                CustomerName = "empty",
                BarcodeTxt = -1,
                LendDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(2),
                Counter = -1,
            }));
        }

        private ObservableCollection<ProductUserControl> userControls = new();
        public ObservableCollection<ProductUserControl> UserControls
        {
            get { return userControls; }
            set { userControls = value; 
                NotifyPropertyChanged(nameof(UserControls));
            }
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
