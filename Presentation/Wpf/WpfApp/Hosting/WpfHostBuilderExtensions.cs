using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.Hosting
{
    public static class WpfHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWPF<TWindow>(this IHostBuilder hostBuilder) where TWindow : Window
        {
            hostBuilder.ConfigureServices((hostBuilderContext, serviceCollection) => serviceCollection
                .AddSingleton<IHostLifetime, WpfAppLifetime>()
                .AddHostedService<WpfAppHostedService<TWindow>>());
            return hostBuilder;
        }
    }
}
