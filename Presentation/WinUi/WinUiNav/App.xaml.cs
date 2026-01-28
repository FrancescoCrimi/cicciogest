// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WinUiBackend;
using CiccioGest.Presentation.WinUiNav.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace CiccioGest.Presentation.WinUiNav
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            var gestConf = CiccioGestConfMgr.GetCurrent();

            builder.Services
                .AddSingleton(gestConf)
                .ConfigureWinUiBackend(gestConf)
                .AddTransient<MainView>();

            IHost host = builder.Build();
            await host.StartAsync();

            host.Services.GetRequiredService<MainView>().Activate();
        }
    }
}
