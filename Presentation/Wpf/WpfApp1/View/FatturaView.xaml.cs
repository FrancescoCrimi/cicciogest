﻿using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FatturaView : Window
    {
        public FatturaView(FatturaViewModel fatturaViewModel )
        {
            InitializeComponent();
            DataContext = fatturaViewModel;
        }
    }
}
