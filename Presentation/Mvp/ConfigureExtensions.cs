using CiccioGest.Presentation.Client;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CiccioGest.Presentation.Mvp
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureMvp(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .ConfigureClient()
                .AddTransient<WindowService>()
                .AddTransient<DialogService>()
                .AddTransient<MainPresenter>()
                .AddTransient<ListaFatturePresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<ListaClientiPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<ArticoloPresenter>()
                .AddTransient<ListaFornitoriPresenter>()
                .AddTransient<ListaArticoliPresenter>()
                .AddTransient<SelectClientePresenter>();
            return serviceCollection;
        }
    }
}
