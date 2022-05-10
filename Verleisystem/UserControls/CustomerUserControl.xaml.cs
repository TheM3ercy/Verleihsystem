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

namespace Verleihsystem.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerUserControl.xaml
    /// </summary>
    public partial class CustomerUserControl : UserControl
    {
        public CustomerUserControl()
        {
            InitializeComponent();
        }

        [Category("Data"), Description("Name of CustomerUserControl")]
        public string CustomerName
        {
            get { return (string)customername.Content; }
            set { customername.Content = value; }
        }
        [Category("Data"), Description("ID of CustomerUserControl")]
        public string CustomerId
        {
            get { return (string)customerid.Content; }
            set { customerid.Content = value; }
        }

        [Category("Data"), Description("Telephonenumber of CustomerUserControl")]
        public string CustomerTel
        {
            get { return (string)customerTel.Content; }
            set { customerTel.Content = value; }
        }
        [Category("Data"), Description("Email of CustomerUserControl")]
        public string CustomerEmail
        {
            get { return (string)customerEmail.Content; }
            set { customerEmail.Content = value; }
        }
    }
}
