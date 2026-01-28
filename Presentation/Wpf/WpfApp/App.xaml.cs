// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp.Views;
using CiccioGest.Presentation.WpfBackend;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp
{
    public partial class App : System.Windows.Application
    {
        private async void OnStartup(object sender, StartupEventArgs e)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(e.Args);

            var gestConf = CiccioGestConfMgr.GetCurrent();

            builder.Services
                .AddSingleton(gestConf)
                .ConfigureWpfBackend(gestConf)
                .AddTransient<MainView>();

            IHost host = builder.Build();
            await host.StartAsync();

            //var persistenceInitializer = Ioc.Default.GetRequiredService<IPersistenceInitializer>();
            //Task.Run(async () => await persistenceInitializer.OnNavigatedToAsync(true));

            host.Services.GetRequiredService<MainView>().Show();
        }
    }
}
