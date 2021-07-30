using CiccioGest.Presentation.Mvp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CiccioGest.Presentation.AppGtk.Hosting
{
    public static class GtkHostBuilderExtensions
    {
        public static IHostBuilder ConfigureGtk<TPresenter>(this IHostBuilder hostBuilder) where TPresenter : IPresenter
        {
            return hostBuilder
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                    serviceCollection
                        .AddSingleton<IHostLifetime, GtkHostLifetime>()
                        .AddHostedService<GtkHostedService<TPresenter>>());
        }
    }
}
