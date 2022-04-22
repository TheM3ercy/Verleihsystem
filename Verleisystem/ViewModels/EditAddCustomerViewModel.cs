using MvvmTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Verleihsystem.ViewModels
{
    public class EditAddCustomerViewModel : ObservableObject
    {
        private static Action closeAction;

        public EditAddCustomerViewModel(Action closeAction)
        {
            EditAddCustomerViewModel.closeAction = closeAction;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public ICommand AbortCommand = new RelayCommand<string>(_ => closeAction.Invoke());
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
        },
        _ => Name != null && Name != ""
            && Telephone != null && Telephone != ""
            && Email != null && Email != "" && Email.Contains("@"));
    }
}
