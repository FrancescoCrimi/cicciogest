// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiMenu.Views;
using Microsoft.UI.Xaml;

namespace CiccioGest.Presentation.WinUiMenu
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        public App()
        {
            InitializeComponent();
            ConfigureServiceProvider.ConfigureWinUiMenu();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Ioc.Default.GetRequiredService<MainView>().Activate();
        }
    }
}