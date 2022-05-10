﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Verleihsystem.ViewModels;

namespace Verleihsystem.Windows
{
    /// <summary>
    /// Interaction logic for EditAddProduct.xaml
    /// </summary>
    public partial class EditAddProduct : Window
    {
        public EditAddProduct(EditAddProductViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
