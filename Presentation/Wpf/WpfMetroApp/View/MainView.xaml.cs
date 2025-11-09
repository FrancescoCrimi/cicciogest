// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModel;
using CiccioGest.Presentation.WpfBackend.Services;
using MahApps.Metro.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class MainView : MetroWindow
    {
        public MainView(MainViewModel viewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
