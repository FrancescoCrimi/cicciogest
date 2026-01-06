// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiMenu.Views;
using Microsoft.UI.Xaml;

namespace CiccioGest.Presentation.WinUiMenu
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        public static Window MainWindow { get; set; } = new Window();

        public App()
        {
            InitializeComponent();
            ConfigureServiceProvider.ConfigureWinUiMenu();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            App.MainWindow.Content = Ioc.Default.GetService<MainView>();
            App.MainWindow.Activate();
            Ioc.Default.GetRequiredService<INavigationService>().Navigate<DashboardViewModel>();
        }
    }
}