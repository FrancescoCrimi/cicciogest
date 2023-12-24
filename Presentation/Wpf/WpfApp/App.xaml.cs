using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp.Services;
using CiccioGest.Presentation.WpfApp.View;
using CiccioGest.Presentation.WpfBackend;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace CiccioGest.Presentation.WpfApp
{
    public partial class App : System.Windows.Application
    {
        private void OnStartup(object sender, System.Windows.StartupEventArgs e)
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

                .AddSingleton<NavigationService>()
                .AddSingleton<INavigationService>(s => s.GetRequiredService<NavigationService>())
                .AddSingleton<PageService>()
                .AddSingleton<IMessageBoxService, MessageBoxService>()
                .AddTransient<MainView>()
                .AddTransient<HomeView>()
                .AddTransient<ArticoliView>()
                .AddTransient<ArticoloView>()
                .AddTransient<CategoriaView>()
                .AddTransient<ClienteView>()
                .AddTransient<ClientiView>()
                .AddTransient<FatturaView>()
                .AddTransient<FattureView>()
                .AddTransient<FornitoreView>()
                .AddTransient<FornitoriView>()
                .AddTransient<ListaArticoliView>()
                .AddTransient<ListaClientiView>()
                .AddTransient<ListaFattureView>()
                .AddTransient<ListaFornitoriView>()
                .BuildServiceProvider();
        }
    }
}
