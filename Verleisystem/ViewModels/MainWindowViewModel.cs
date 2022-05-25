using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Verleihsystem.Services;
using Verleihsystem.UserControls;
using Verleihsystem.Windows;

namespace Verleihsystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private IServiceProvider serviceProvider;
        private DbService dbService;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            if (serviceProvider.GetService(typeof(DbService)) == null) throw new ArgumentNullException();
            dbService = serviceProvider.GetService(typeof(DbService)) as DbService;
            if (dbService == null) throw new ArgumentNullException();
            FillWithProductUserControls();
        }

        private void FillWithCategoryUserControls()
        {
            UserControls = new();
            var dbservice = serviceProvider.GetService(typeof(DbService)) as DbService;
            dbservice!.GetAllCategories().ForEach(x =>
            {
                var userControl = new CategoryUserControl
                {
                   CategoryId = x.id,
                   CategoryName = x.name,
                   CategoryDescription = x.beschreibung,
                };
                UserControls.Add(userControl);
            });
        }

        private void FillWithCustomerUserControls()
        {
            UserControls = new();
            var dbservice = serviceProvider.GetService(typeof(DbService)) as DbService;
            dbservice!.GetAllCustomers().ForEach(x =>
            {
                var userControl = new CustomerUserControl
                {
                    CustomerId = x.Id,
                    CustomerName = x.Name,
                    CustomerEmail = x.Email,
                    CustomerTel = x.Tel,
                };
                UserControls.Add(userControl);
            });
        }

        private void FillWithProductUserControls()
        {
            UserControls = new();
            var dbservice = serviceProvider.GetService(typeof(DbService)) as DbService;
            dbservice!.GetAllProducts().ForEach(x =>
            {
                var userControl = new ProductUserControl
                {
                    ProductName = x.name,
                    CategoryName = x.kategorie,
                    CustomerName = "empty",
                    BarcodeTxt = -1,
                    LendDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(2),
                    Counter = -1,
                };
                userControl.SelectedEvent += ProductUserControlSelected;
                userControl.EditEvent += ProductUserControlEdit;
                UserControls.Add(userControl);
            });
        }

        private ObservableCollection<UserControl> userControls = new();
        public ObservableCollection<UserControl> UserControls
        {
            get { return userControls; }
            set { userControls = value; 
                NotifyPropertyChanged(nameof(UserControls));
            }
        }

        public void ProductUserControlSelected(object sender, ProductUserControlSelectedEventArgs e)
        {
            var window = serviceProvider.GetService(typeof(EditAddProduct)) as Window;
            window.Show();
        }

        public void ProductUserControlEdit(object sender, ProductUserControlSelectedEventArgs e)
        {
            var window = serviceProvider.GetService(typeof(BorrowProduct)) as Window;
            window.Show();
        }

        #region
        //public ICommand OpenBorrowProductMenu = new RelayCommand<string>(_ =>
        //{
        //    var window = serviceProvider.GetService(typeof(BorrowProduct)) as Window;
        //    window.Show();
        //});

        //public ICommand OpenEditAddCategoryWindow = new RelayCommand<string>(_ =>
        //{
        //    var window = serviceProvider.GetService(typeof(EditAddCategory)) as Window;
        //    window.Show();
        //});

        //public ICommand OpenEditAddCustomerWindow = new RelayCommand<string>(_ =>
        //{
        //    var window = serviceProvider.GetService(typeof(EditAddCustomer)) as Window;
        //    window.Show();
        //});

        //public ICommand OpenEditAddProductWindow = new RelayCommand<string>(_ =>
        //{
        //    var window = serviceProvider.GetService(typeof(EditAddProduct)) as Window;
        //    window.Show();
        //});
        #endregion
    }
}
