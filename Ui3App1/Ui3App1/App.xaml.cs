using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Ui3App1.Services;
using CiccioGest.Presentation.Ui3App1.View;
using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Ui3App1;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using NLog.Extensions.Logging;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CiccioGest.Presentation.Ui3App1
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Microsoft.UI.Xaml.Application
    {
        //public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName".GetLocalized() };
        public static Window MainWindow { get; set; } = new Window() { Title = "AppDisplayName" };

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            //m_window = new MainWindow();
            //m_window.Activate();

            if (App.MainWindow.Content == null)
            {
                //UIElement _shell = Ioc.Default.GetService<MainView>();
                //App.MainWindow.Content = _shell ?? new Frame();

                Frame rootFrame = new Frame();
                App.MainWindow.Content = rootFrame;
                rootFrame.Navigate(typeof(MainView), args.Arguments);
            }
            App.MainWindow.Activate();
        }

        //private Window m_window;


        private System.IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services
                .AddLogging(loggingBuilder => 
                    loggingBuilder.AddNLog())
                .AddSingleton(CiccioGestConfMgr.GetCurrent())
                .ConfigureApplication()
                .AddTransient<MainViewModel>()
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
                .AddSingleton<NavigationService>()
                .AddSingleton<INavigationService>(s => s.GetService<NavigationService>())
                .AddSingleton<PageService>();
            return services.BuildServiceProvider();
        }
    }
}
