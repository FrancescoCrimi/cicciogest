// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using MahApps.Metro.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.Views
{
    public sealed partial class MainView : MetroWindow
    {
        public MainView(MainViewModel viewModel,
                        INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = viewModel;
            _ = navigationService.Navigate<DashboardViewModel>();
        }
    }
}
