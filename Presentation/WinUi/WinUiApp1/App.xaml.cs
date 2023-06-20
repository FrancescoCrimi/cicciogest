using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WinUiApp1.Activation;
using CiccioGest.Presentation.WinUiApp1.Services;
using CiccioGest.Presentation.WinUiApp1.View;
using CiccioGest.Presentation.WinUiApp1.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using NLog.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.WinUiApp1
{
    public partial class App : Microsoft.UI.Xaml.Application
    {
        //public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName" };

        public App()
        {
            InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            await Ioc.Default.GetService<ActivationService>().ActivateAsync(args);
        }

        private IServiceProvider ConfigureServices() => new ServiceCollection()

            .AddLogging(loggingBuilder => loggingBuilder.AddNLog())
            .AddSingleton(CiccioGestConfMgr.GetCurrent())
            .ConfigureApplication()

            // Default Activation Handler
            .AddTransient<ActivationHandler<Microsoft.UI.Xaml.LaunchActivatedEventArgs>, DefaultActivationHandler>()

            // Other Activation Handlers

            // Services
            .AddSingleton<ActivationService>()
            .AddSingleton<PageService>()
            .AddSingleton<NavigationService>()
            .AddSingleton<INavigationService>(s => s.GetService<NavigationService>())

            // View
            .AddTransient<ShellView>()

            // ViewModel
            .AddTransient<ShellViewModel>()
            .AddTransient<ArticoloViewModel>()
            .AddTransient<ArticoliViewModel>()
            .AddTransient<CategoriaViewModel>()
            .AddTransient<ClienteViewModel>()
            .AddTransient<ClientiViewModel>()
            .AddTransient<FatturaViewModel>()
            .AddTransient<FattureViewModel>()
            .AddTransient<FornitoreViewModel>()
            .AddTransient<FornitoriViewModel>()
            .AddTransient<ListaArticoliViewModel>()
            .AddTransient<ListaClientiViewModel>()
            .AddTransient<ListaFattureViewModel>()
            .AddTransient<ListaFornitoriViewModel>()

            .BuildServiceProvider();
    }
}

