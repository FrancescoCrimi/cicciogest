// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WinUiBackend;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CiccioGest.Presentation.WinUiNav.Activation;
using CiccioGest.Presentation.WinUiNav.Services;
using CiccioGest.Presentation.WinUiNav.View;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

namespace CiccioGest.Presentation.WinUiNav
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        public static Window MainWindow { get; } = new MainWindow();

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
