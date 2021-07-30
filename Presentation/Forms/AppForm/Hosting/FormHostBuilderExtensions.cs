using CiccioGest.Presentation.Mvp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Hosting
{
    public static class FormHostBuilderExtensions
    {
        public static IHostBuilder ConfigureWinForms<TForm>(this IHostBuilder hostBuilder) where TForm : IPresenter
        {
            return hostBuilder
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                    serviceCollection
                        .AddSingleton<IHostLifetime, FormHostLifetime>()
                        .AddHostedService<FormHostedService<TForm>>());
        }
    }
}
