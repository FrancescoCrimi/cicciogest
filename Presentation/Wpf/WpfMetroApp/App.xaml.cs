// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfBackend;
using CiccioGest.Presentation.WpfBackend.Services;
using CiccioGest.Presentation.WpfMetroApp.Services;
using CiccioGest.Presentation.WpfMetroApp.View;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace CiccioGest.Presentation.WpfMetroApp
{
    public partial class App : System.Windows.Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
            => ConfigureServices().GetRequiredService<MainView>().Show();

        private static IServiceProvider ConfigureServices()
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();

            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation!)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            return new ServiceCollection()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddNLog();
                    loggingBuilder.AddDebug();
                })

                .AddSingleton(gestConf)
                .ConfigureWpfBackend()

                .AddSingleton<PageService>()
                .AddSingleton<IPageService>(s => s.GetRequiredService<PageService>())

                .AddTransient<MainView>()
                .AddTransient<ArticoliView>()
                .AddTransient<ArticoloView>()
                .AddTransient<CategoriaView>()
                .AddTransient<ClienteView>()
                .AddTransient<ClientiView>()
                .AddTransient<FatturaView>()
                .AddTransient<FattureView>()
                .AddTransient<FornitoreView>()
                .AddTransient<FornitoriView>()
                .BuildServiceProvider();
        }
    }
}
