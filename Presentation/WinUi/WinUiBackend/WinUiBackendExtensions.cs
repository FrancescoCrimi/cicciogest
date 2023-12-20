using CiccioGest.Application.Impl;
using CiccioGest.Presentation.WinUiBackend.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.WinUiBackend
{
    public static class WinUiBackendExtensions
    {
        public static IServiceCollection ConfigureWinUiBackend(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .ConfigureApplication()

                // ViewModel
                .AddTransient<ShellViewModel>()
                .AddTransient<DashboardViewModel>()
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
                .AddTransient<ListaFornitoriViewModel>();
        }
    }
}
