// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiMenu.Services;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiMenu.Views
{
    public sealed partial class MainView : Page
    {
        public MainView(NavigationService navigationService,
                        MainViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = mainViewModel;
        }
    }
}
