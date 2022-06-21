using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Verleihsystem.Dtos;
using Verleihsystem.Services;

namespace Verleihsystem.ViewModels
{
    public class BorrowProductViewModel : ObservableObject
    {
        private IServiceProvider serviceProvider;
        private DbService dbService;

        public BorrowProductViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            dbService = serviceProvider.GetService(typeof(DbService)) as DbService;
            FillProducts();
            FillCustomers();
        }

        private void FillProducts()
        {
            dbService.GetAllProducts().ToList().ForEach(x => Products.Add(x));
        }

        private void FillCustomers()
        {
            dbService.GetAllCustomers().ToList().ForEach(x => Customers.Add(x));
        }

        private ProductDto product;
        public ProductDto Product
        {
            get { return product; }
            set { product = value;
                NotifyPropertyChanged(nameof(Product));
            }
        }

        private ObservableCollection<ProductDto> products = new();
        public ObservableCollection<ProductDto> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged(nameof(Products));
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set { category = value;
                NotifyPropertyChanged(nameof(Category));
            }
        }

        private string startDate;
        public string StartDate
        {
            get { return startDate; }
            set { startDate = value;
                NotifyPropertyChanged(nameof(StartDate));
            }
        }

        private string endDate;
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value;
                NotifyPropertyChanged(nameof(EndDate));
            }
        }

        private CustomerDto customer;
        public CustomerDto Customer
        {
            get { return customer; }
            set { customer = value;
                NotifyPropertyChanged(nameof(Customer));
            }
        }

        private ObservableCollection<CustomerDto> customers = new();
        public ObservableCollection<CustomerDto> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                NotifyPropertyChanged(nameof(Customers));
            }
        }

        private string employee;
        public string Employee
        {
            get { return employee; }
            set { employee = value;
                NotifyPropertyChanged(nameof(Employee));
            }
        }

        private RelayCommand<Window> abortCommand;
        public ICommand AbortCommand
        {
            get
            {
                if (abortCommand == null)
                {
                    abortCommand = new RelayCommand<Window>(x => x.Close());
                }
                return abortCommand;
            }
        }

        private RelayCommand<Window> confirmCommand;
        public ICommand ConfirmCommand
        {
            get
            {
                if (confirmCommand == null)
                {
                    confirmCommand = new RelayCommand<Window>(x => Console.WriteLine(dbService.PostLeasedProduct(Product.id, Customer.id)), 
                        _ => Product != null && Customer != null);
                }
                return confirmCommand;
            }
        }
    }
}
