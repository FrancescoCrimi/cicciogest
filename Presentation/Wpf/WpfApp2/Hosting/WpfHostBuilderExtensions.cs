using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp2.Hosting
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
