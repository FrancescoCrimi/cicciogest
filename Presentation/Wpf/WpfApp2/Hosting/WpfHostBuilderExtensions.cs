using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.Hosting
{
    public static class WpfHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWPF<TShell>(this IHostBuilder hostBuilder) where TShell : Window
        {
            hostBuilder.ConfigureServices((hostBuilderContext, serviceCollection) => serviceCollection
                .AddSingleton<IHostLifetime, WpfAppLifetime>()
                .AddHostedService<WpfAppHostedService<TShell>>()
                .AddSingleton<INavigationService, NavigationService>());
            return hostBuilder;
        }
    }
}
