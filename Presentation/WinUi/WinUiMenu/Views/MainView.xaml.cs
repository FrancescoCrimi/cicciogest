// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiBackend.Services;
using Microsoft.UI.Xaml;
using WinUIEx;

namespace CiccioGest.Presentation.WinUiMenu.Views
{
    public sealed partial class MainView : WindowEx
    {
        public MainViewModel ViewModel { get; }

        public MainView(NavigationService navigationService,
                          MainViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(contentControl);
            ViewModel = mainViewModel;
        }

        private async void WindowEx_Activated(object sender, WindowActivatedEventArgs args)
        {
            await ViewModel.LoadedCommand.ExecuteAsync(null);
        }

        private void WindowEx_Closed(object sender, WindowEventArgs args)
        {
            ViewModel.UnloadedCommand.Execute(null);
        }
    }
}
