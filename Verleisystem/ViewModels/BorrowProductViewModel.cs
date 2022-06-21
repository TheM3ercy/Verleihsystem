using System;
using System.Collections.Generic;
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

        public BorrowProductViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value;
                NotifyPropertyChanged(nameof(ProductName));
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

        private string customer;
        public string Customer
        {
            get { return customer; }
            set { customer = value;
                NotifyPropertyChanged(nameof(Customer));
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

        public ICommand AbortCommand = new RelayCommand<Window>(x => x.Close());
        public ICommand ConfirmCommand = new RelayCommand<string>(_ =>
        {
        });
    }
}
