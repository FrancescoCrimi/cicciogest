// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using WinUIEx;

namespace CiccioGest.Presentation.WinUiMenu.Views
{
    public sealed partial class MainView : WindowEx
    {
        public MainView(INavigationService navigationService,
                        MainViewModel mainViewModel)
        {
            InitializeComponent();
            Root.DataContext = mainViewModel;
            _ = navigationService.Navigate<DashboardViewModel>();
        }
    }
}
