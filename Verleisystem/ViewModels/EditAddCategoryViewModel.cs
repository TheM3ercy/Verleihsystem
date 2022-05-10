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
    public class EditAddCategoryViewModel : ObservableObject
    {
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                NotifyPropertyChanged(nameof(CategoryName));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged(nameof(Description));
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
