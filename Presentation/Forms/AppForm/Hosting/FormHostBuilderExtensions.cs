using CiccioGest.Presentation.AppForm.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Hosting
{
    public static class FormHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWinForms<TForm>(this IHostBuilder hostBuilder) where TForm : PresenterBase
        {
            return hostBuilder
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                    serviceCollection
                        .AddSingleton<IHostLifetime, FormHostLifetime>()
                        .AddHostedService<FormHostedService<TForm>>());
        }
    }
}
