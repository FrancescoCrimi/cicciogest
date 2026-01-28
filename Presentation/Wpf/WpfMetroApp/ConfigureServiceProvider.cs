// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfBackend;
using CiccioGest.Presentation.WpfMetroApp.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;

namespace CiccioGest.Presentation.WpfMetroApp
{
    public static class ConfigureServiceProvider
    {
        public static void ConfigureWpfMetroApp()
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation!)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            // Configuration code for WpfMetroApp goes here
            Ioc.Default.ConfigureServices(
                new ServiceCollection()

                // Add services specific to WpfMetroApp
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddDebug();
                })

                .AddSingleton(gestConf)
                .ConfigureWpfBackend(gestConf)

                .AddTransient<MainView>()

                .BuildServiceProvider());
        }
    }
}
