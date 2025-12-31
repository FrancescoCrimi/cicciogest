// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.WpfApp.Services;
using CiccioGest.Presentation.WpfApp.Views;
using CiccioGest.Presentation.WpfBackend;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.IO;
using System.Reflection;

namespace CiccioGest.Presentation.WpfApp
{
    public static class ConfigureServiceProvider
    {
        public static void ConfigureWpfApp()
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation!)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            Ioc.Default.ConfigureServices(

                new ServiceCollection()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddNLog();
                    loggingBuilder.AddDebug();
                })

                .AddSingleton(gestConf)
                .ConfigureWpfBackend(gestConf)

                .AddSingleton<PageService>()
                .AddSingleton<IPageService>(s => s.GetRequiredService<PageService>())

                .AddTransient<MainView>()

                .BuildServiceProvider());
        }
    }
}
