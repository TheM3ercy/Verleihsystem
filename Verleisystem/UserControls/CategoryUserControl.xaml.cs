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
    /// Interaction logic for CategoryUserControl.xaml
    /// </summary>
    public partial class CategoryUserControl : UserControl
    {
        public CategoryUserControl()
        {
            InitializeComponent();
        }

        [Category("Data"), Description("Name of Category")]
        public string CategoryName
        {
            get { return (string)categoryname.Content; }
            set { categoryname.Content = value; }
        }

        [Category("Data"), Description("Id of Category")]
        public string CategoryId
        {
            get { return (string)categoryid.Content; }
            set { categoryid.Content = value; }
        }
        [Category("Data"), Description("Description of Category")]
        public string CategoryDesription
        {
            get { return (string)categoryDescripton.Content; }
            set { categoryDescripton.Content = value; }
        }
    }
}
