
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
    public class EditAddProductViewModel : ObservableObject
    {
        private DbService dbService;

        public EditAddProductViewModel(DbService dbservice)
        {
            this.dbService = dbservice;
            FillCategories();
        }

        public void FillCategories()
        {
            dbService.GetAllCategories().ForEach(c => Categories.Add(c));
        }

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

        private ObservableCollection<CategoryDto> categories = new();
        public ObservableCollection<CategoryDto> Categories
        {
            get { return categories; }
            set { categories = value;
                NotifyPropertyChanged(nameof(Categories));
            }
        }

        private CategoryDto selectedCategory;
        public CategoryDto SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value;
                NotifyPropertyChanged(nameof(SelectedCategory));
            }
        }

        public ICommand AbortCommand = new RelayCommand<Window>(x => x.Close());

        private RelayCommand<string> createProductCommand;
        public ICommand CreateProductCommand
        {
            get
            {
                if (createProductCommand == null)
                {
                    createProductCommand = new RelayCommand<string>(_ =>
                    {
                        dbService.PostProduct(new ProductDto
                        {
                            name = ProductName,
                            code = Code,
                            kategorie = SelectedCategory.id,
                        });
                    });
                }
                return createProductCommand;
            }
        }
    }
}
