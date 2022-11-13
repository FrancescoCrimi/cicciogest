﻿using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class FatturaView : Page
    {
        public FatturaView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<FatturaViewModel>();
        }
    }
}
