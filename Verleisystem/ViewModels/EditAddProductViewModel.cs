
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

        private string code;
        public string Code
        {
            get { return code; }
            set { code = value;
                NotifyPropertyChanged(nameof(Code));
            }
        }

        private List<CategoryDto> categories;
        public List<CategoryDto> Categories
        {
            get { return categories; }
            set { categories = value;
                NotifyPropertyChanged(nameof(Categories));
            }
        }

        private List<CategoryDto> selectedCategories;
        public List<CategoryDto> SelectedCategories
        {
            get { return selectedCategories; }
            set { selectedCategories = value;
                NotifyPropertyChanged(nameof(SelectedCategories));
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
