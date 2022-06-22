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
using Verleihsystem.Services.EventArgs;
using Verleihsystem.UserControls;
using Verleihsystem.Windows;

namespace Verleihsystem.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private IServiceProvider serviceProvider;
        private DbService dbService;

        private bool leased = false;

        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            if (serviceProvider.GetService(typeof(DbService)) == null) throw new ArgumentNullException();
            dbService = serviceProvider.GetService(typeof(DbService)) as DbService;
            if (dbService == null) throw new ArgumentNullException();
            var homeribbon = new HomeRibbon();
            HomeRibbon = homeribbon;
            FillWithProductUserControls();
        }

        public void Selected(object sender, ViewRibbonSelectedEventArgs e)
        {
            switch (e.ViewContent){
                case 1:
                    {
                        FillWithCustomerUserControls();
                        break;
                    }
                case 2:
                    {
                        FillWithCategoryUserControls();
                        break;
                    }
                case 3:
                    {
                        FillWithProductUserControls();
                        break;
                    }
            }
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
            dbservice!.GetAllCustomers().ToList().ForEach(x =>
            {
                var userControl = new CustomerUserControl
                {
                    CustomerId = x.id,
                    CustomerName = x.name,
                    CustomerEmail = x.email,
                    CustomerTel = x.tel,
                };
                UserControls.Add(userControl);
            });
        }

        private void FillWithProductUserControls()
        {
            UserControls = new();
            var dbservice = serviceProvider.GetService(typeof(DbService)) as DbService;
            dbservice!.GetAllProducts().ToList().ForEach(x =>
            {
                var userControl = new ProductUserControl
                {
                    Id = x.id,
                    ProductName = x.name,
                    CategoryName = x.kategorie,
                    CustomerName = "empty",
                    BarcodeTxt = -1,
                    LendDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(2),
                    Counter = -1,
                };
                userControl.SelectedEvent += ProductUserControlSelected;
                UserControls.Add(userControl);
            });
        }

        private void FillWithLeasedProductUserControl()
        {
            UserControls = new();
            var dbservice = serviceProvider.GetService(typeof(DbService)) as DbService;
            dbservice.GetAllLeasedProducts().ForEach(y => 
            {
                dbservice!.GetAllProducts().Where(x => y.produkt_id == x.id).ToList().ForEach(x =>
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
                    UserControls.Add(userControl);
                });
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

        private UserControl selectedUserControl;
        public UserControl SelectedUserControl
        {
            get { return selectedUserControl; }
            set { selectedUserControl = value; }
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

        private HomeRibbon homeRibbon;
        public HomeRibbon HomeRibbon
        {
            get { return homeRibbon; }
            set { homeRibbon = value;}
        }

        private RelayCommand<string> consoleCommand;
        public ICommand ConsoleCommand
        {
            get
            {
                if (consoleCommand == null)
                {
                    consoleCommand = new RelayCommand<string>(_ => Console.WriteLine("Test"));
                }
                return consoleCommand;
            }
        }

        private RelayCommand<string> lendProductCommand;
        public ICommand LendProductCommand
        {
            get
            {
                if (lendProductCommand == null)
                {
                    lendProductCommand = new RelayCommand<string>(_ =>
                    {
                        var window = serviceProvider.GetService(typeof(BorrowProduct)) as Window;
                        window.Show();
                    });
                }
                return lendProductCommand;
            }
        }

        private RelayCommand<string> showLentProductsCommand;
        public ICommand ShowLentProductsCommand
        {
            get
            {
                if (showLentProductsCommand == null)
                {
                    showLentProductsCommand = new RelayCommand<string>(_ => 
                    {
                        if (!leased)
                        {
                            FillWithLeasedProductUserControl();
                            leased = true;
                        } 
                        else
                        {
                            FillWithProductUserControls();
                            leased = false;
                        }
                    });
                }
                return showLentProductsCommand;
            }
        }

        private RelayCommand<string> showCategoriesCommand;
        public ICommand ShowCategoriesCommand
        {
            get
            {
                if (showCategoriesCommand == null)
                {
                    showCategoriesCommand = new RelayCommand<string>(_ =>
                    {
                        FillWithCategoryUserControls();
                        leased = false;
                    });
                }
                return showCategoriesCommand;
            }
        }

        private RelayCommand<string> showCustomersCommand;
        public ICommand ShowCustomersCommand
        {
            get
            {
                if (showCustomersCommand == null)
                {
                    showCustomersCommand = new RelayCommand<string>(_ =>
                    {
                        FillWithCustomerUserControls();
                        leased = false;
                    });
                }
                return showCustomersCommand;
            }
        }

        private RelayCommand<string> showProductsCommand;
        public ICommand ShowProductsCommand
        {
            get
            {
                if (showProductsCommand == null)
                {
                    showProductsCommand = new RelayCommand<string>(_ =>
                    {
                        FillWithProductUserControls();
                        leased = false;
                    });
                }
                return showProductsCommand;
            }
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
