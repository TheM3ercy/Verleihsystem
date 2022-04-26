
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Verleihsystem.Services;

namespace Verleihsystem.ViewModels
{
    public class EditAddProductViewModel : ObservableObject
    {
        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; 
                NotifyPropertyChanged(nameof(ProductName));     
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }

        public ICommand AbortCommand = new RelayCommand<Window>(x => x.Close());
        public ICommand ContinueCommand = new RelayCommand<string>(_ =>
        {
            if (false/*Database contains name*/)
            {
                /*Edit Database entry*/
            }
            else
            {
                /*Create new Database entry*/
            }
        });
    }
}
