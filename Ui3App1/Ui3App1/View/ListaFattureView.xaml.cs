﻿using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Ui3App1.View
{
    public sealed partial class ListaFattureView : Page
    {
        public ListaFattureView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ListaFattureViewModel>();
        }
    }
}
