using CiccioGest.Application.Impl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp
{
    sealed partial class App : Windows.UI.Xaml.Application
    {
        public App()
        {
            InitializeComponent();
            Ioc.Default.ConfigureServices(ConfigureServices());
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services
                .AddLogging()
                .AddSingleton(CiccioGestConfMgr.GetCurrent())
                .ConfigureApplication()
                .AddSingleton<NavigationService>()
                .AddTransient<ShellViewModel>()
                .AddTransient<FatturaViewModel>()
                .AddTransient<ArticoloViewModel>()
                .AddTransient<CategoriaViewModel>()
                .AddTransient<ListaFattureViewModel>()
                .AddTransient<ListaArticoliViewModel>();
            return services.BuildServiceProvider();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Non ripetere l'inizializzazione dell'applicazione se la finestra già dispone di contenuto,
            // assicurarsi solo che la finestra sia attiva
            if (rootFrame == null)
            {
                // Creare un frame che agisca da contesto di navigazione e passare alla prima pagina
                rootFrame = new Frame();

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: caricare lo stato dall'applicazione sospesa in precedenza
                }

                // Posizionare il frame nella finestra corrente
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // Quando lo stack di esplorazione non viene ripristinato, passare alla prima pagina
                    // configurando la nuova pagina per passare le informazioni richieste come parametro di
                    // navigazione
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Assicurarsi che la finestra corrente sia attiva
                Window.Current.Activate();
            }
        }
    }
}
