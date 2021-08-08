﻿using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class MainView : Window
    {
        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}
