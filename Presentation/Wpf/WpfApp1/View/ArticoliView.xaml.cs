﻿using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoliView : Window
    {
        private readonly ArticoliViewModel viewModel;

        public ArticoliView(ArticoliViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = viewModel;
            viewModel.OnRequestClose += ViewModel_OnRequestClose;
        }

        private void ViewModel_OnRequestClose(object sender, EventArgs e)
        {
            viewModel.OnRequestClose -= ViewModel_OnRequestClose;
            Close();
        }
    }
}
