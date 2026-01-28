// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.Views
{
    public sealed partial class MainView : Window
    {
        public MainView(MainViewModel mainViewModel,
                        INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = mainViewModel;
            _ = navigationService.Navigate<DashboardViewModel>();
        }
    }
}
