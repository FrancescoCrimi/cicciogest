// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WinUiMenu.Activation;
using CiccioGest.Presentation.WinUiMenu.Services;
using CiccioGest.Presentation.WinUiMenu.View;
using CiccioGest.Presentation.WinUiBackend;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using NLog.Extensions.Logging;
using System;

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

        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            await Ioc.Default.GetService<ActivationService>().ActivateAsync(args);
        }

        private IServiceProvider ConfigureServices() => new ServiceCollection()

            //.AddLogging(loggingBuilder => loggingBuilder.AddNLog())
            .AddLogging()
            .AddSingleton(CiccioGestConfMgr.GetCurrent())
            .ConfigureWinUiBackend()

            // Default Activation Handler
            .AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>()

            // Other Activation Handlers

            // Services
            .AddSingleton<ActivationService>()
            .AddSingleton<PageService>()
            .AddSingleton<NavigationService>()
            .AddSingleton<INavigationService>(s => s.GetService<NavigationService>())

            // View
            .AddTransient<ShellView>()

            .BuildServiceProvider();
    }
}