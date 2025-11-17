// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.WinUiBackend;
using CiccioGest.Presentation.WinUiMenu.Services;
using CiccioGest.Presentation.WinUiMenu.Views;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace CiccioGest.Presentation.WinUiMenu
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        public static Window MainWindow { get; set; } = new Window();

        public App()
        {
            InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            App.MainWindow.Content = Ioc.Default.GetService<MainView>();
            App.MainWindow.Activate();
            Ioc.Default.GetService<INavigationService>().Navigate(ViewEnum.Dashboard, args.Arguments);
        }

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
                .ConfigureWinUiBackend()

                // Services
                .AddSingleton<PageService>()
                .AddSingleton<NavigationService>()
                .AddSingleton<INavigationService>(s => s.GetService<NavigationService>())

                // View
                .AddTransient<MainView>()

                .BuildServiceProvider();
        }
    }
}