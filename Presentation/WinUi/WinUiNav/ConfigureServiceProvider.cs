// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.WinUiBackend;
using CiccioGest.Presentation.WinUiBackend.Services;
using CiccioGest.Presentation.WinUiNav.Services;
using CiccioGest.Presentation.WinUiNav.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;

namespace CiccioGest.Presentation.WinUiNav
{
    public static class ConfigureServiceProvider
    {
        public static void ConfigureWinUiNav()
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation!)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            // Configuration code for WinUiNav goes here
            Ioc.Default.ConfigureServices(
                new ServiceCollection()

                // Add services specific to WinUiNav
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    //loggingBuilder.AddNLog();
                    loggingBuilder.AddDebug();
                })

                .AddSingleton(gestConf)
                .ConfigureWinUiBackend(gestConf)

                // Services
                .AddSingleton<PageService>()
                .AddSingleton<IPageService>(s => s.GetRequiredService<PageService>())
                .AddSingleton<NavigationService>()
                .AddSingleton<INavigationService>(s => s.GetRequiredService<NavigationService>())

                // View
                .AddTransient<MainView>()

                .BuildServiceProvider());
        }
    }
}
