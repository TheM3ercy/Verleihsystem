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
    public class EditAddCustomerViewModel : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value;
                NotifyPropertyChanged(nameof(Telephone));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value;
                NotifyPropertyChanged(nameof(Email));
            }
        }

        public ICommand AbortCommand = new RelayCommand<Window>(x => x.Close());
        public ICommand ConfirmCommand = new RelayCommand<string>(_ =>
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
