using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.Hosting;
using CiccioGest.Presentation.WpfApp1.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1
{
    public static class WpfHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWPF<TShell>(this IHostBuilder hostBuilder) where TShell : Window
        {
            hostBuilder
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    serviceCollection
                    .AddSingleton<IHostLifetime, WpfAppLifetime>()
                    .AddHostedService<WpfAppHostedService<TShell>>()
                    .AddSingleton<IWindowManagerService, WindowManagerService>()
                    .AddScoped<IWindowDialogService, WindowDialogService>();
                });
            return hostBuilder;
        }
    }
}
