// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WpfMetroApp.Views;
using System.Windows;

namespace CiccioGest.Presentation.WpfMetroApp
{
    public partial class App : System.Windows.Application
    {
        public App()
        {
            ConfigureServiceProvider.ConfigureWpfMetroApp();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            Ioc.Default.GetRequiredService<MainView>().Show();
        }
    }
}
