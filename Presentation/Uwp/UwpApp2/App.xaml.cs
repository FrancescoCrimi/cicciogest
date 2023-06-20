// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.UwpApp.Activation;
using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpBackend;
using CiccioGest.Presentation.UwpBackend.Services;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.ApplicationModel.Activation;

namespace CiccioGest.Presentation.UwpApp
{
    sealed partial class App : Windows.UI.Xaml.Application
    {
        public App()
        {
            InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (e.PrelaunchActivated == false)
            {
                await Ioc.Default.GetService<ActivationService>().ActivateAsync(e);
            }
        }

        private IServiceProvider ConfigureServices() => new ServiceCollection()
            .AddLogging()
            .AddSingleton(CiccioGestConfMgr.GetCurrent())
            .ConfigureUwpBackend()

            // Default Activation Handler
            .AddTransient<ActivationHandler<IActivatedEventArgs>, DefaultActivationHandler>()

            // Other Activation Handlers

            // Services
            .AddSingleton<ActivationService>()
            .AddSingleton<PageService>()
            .AddSingleton<NavigationService>()
            .AddSingleton<INavigationService>((s) => s.GetService<NavigationService>())
            .BuildServiceProvider();
    }
}
