using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Verleihsystem.Services;
using Verleihsystem.ViewModels;

namespace Verleihsystem.UserControls
{
    /// <summary>
    /// Interaction logic for ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public event EventHandler<ProductUserControlSelectedEventArgs> SelectedEvent;
        public event EventHandler<ProductUserControlSelectedEventArgs> EditEvent;

        public ProductUserControl()
        {
            InitializeComponent();
            stkBackground.MouseRightButtonDown += OnRightClickListener;
            stkBackground.MouseLeftButtonDown += OnLeftClickListener;
        }

        public void OnRightClickListener(object sender, RoutedEventArgs e)
        {
            SelectedEvent?.Invoke(sender, new ProductUserControlSelectedEventArgs { Name = ProductName});
        }

        public void OnLeftClickListener(object sender, RoutedEventArgs e)
        {
            EditEvent?.Invoke(sender, new ProductUserControlSelectedEventArgs { Name = ProductName });
        }

        [Category("Data"), Description("Name of product")]
        public string ProductName
        {
            get { return (string)productname.Content; }
            set { productname.Content = value; }
        }

        [Category("Data"), Description("Name of category")]
        public string CategoryName
        {
            get { return (string)categoryname.Content; }
            set { categoryname.Content = value; }
        }

        [Category("Data"), Description("Name of customer")]
        public string CustomerName
        {
            get { return (string)customer.Content; }
            set { customer.Content = value; }
        }

        [Category("Data"), Description("Barcode as number")]
        public int BarcodeTxt
        {
            get { return (int)barcodetxt.Content; }
            set { barcodetxt.Content = value; }
        }

        [Category("Data"), Description("Barcode image")]
        private Image barcodeImage;
        public Image BarcodeImage
        {
            get { return barcodeImage; }
            set { barcodeImage = value; }
        }

        [Category("Data"), Description("Date of lease")]
        private DateTime lendDate;
        public DateTime LendDate
        {
            get { return lendDate; }
            set { 
                lendDate = value; 
                lenddate.Content = $"{lendDate:dd/MM/yyyy}";
            }
        }

        [Category("Data"), Description("Date of return")]
        private DateTime returnDate;
        public DateTime ReturnDate
        {
            get { return returnDate; }
            set { 
                returnDate = value;
                returndate.Content = $"{returnDate:dd/MM/yyyy}";
            }
        }

        [Category("Data"), Description("Product counter")]
        public int Counter
        {
            get { return (int)countTxt.Content; }
            set { countTxt.Content = value; }
        }

        [Category("Design"), Description("Set Background of user control")]
        private Color backgroundColor = Colors.White;
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { 
                backgroundColor = value; 
                stkBackground.Background = new SolidColorBrush(backgroundColor);
            }
        }
    }
}
