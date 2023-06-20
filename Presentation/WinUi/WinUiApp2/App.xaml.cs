using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WinUiApp2.Activation;
using CiccioGest.Presentation.WinUiApp2.Services;
using CiccioGest.Presentation.WinUiApp2.View;
using CiccioGest.Presentation.WinUiApp2.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

namespace CiccioGest.Presentation.WinUiApp2
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        public static Window MainWindow { get; } = new MainWindow();

        public App()
        {
            InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            await Ioc.Default.GetService<ActivationService>().ActivateAsync(args);
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()

            //.AddLogging(loggingBuilder => loggingBuilder.AddNLog())
            //.AddSingleton(CiccioGestConfMgr.GetCurrent())
            //.ConfigureApplication()

            // Default Activation Handler
            .AddTransient<ActivationHandler<Microsoft.UI.Xaml.LaunchActivatedEventArgs>, DefaultActivationHandler>()

            // Other Activation Handlers

            // Services
            .AddSingleton<ActivationService>()
            .AddSingleton<PageService>()
            .AddSingleton<NavigationService>()
            //.AddSingleton<INavigationService>(s => s.GetService<NavigationService>())

            // View
            .AddTransient<ShellView>()

            // ViewModel
            .AddTransient<ShellViewModel>()

            .BuildServiceProvider();
        }
    }
}
