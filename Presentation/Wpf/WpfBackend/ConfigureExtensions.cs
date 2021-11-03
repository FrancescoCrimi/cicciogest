using CiccioGest.Application.Impl;
using CiccioGest.Presentation.WpfBackend.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CiccioGest.Presentation.WpfBackend
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureWpfBackend(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .ConfigureApplication()
                .AddTransient<MainViewModel>()
                .AddTransient<HomeViewModel>()

                .AddTransient<FatturaViewModel>()
                .AddTransient<FattureViewModel>()
                .AddTransient<ListaFattureViewModel>()

                .AddTransient<ArticoliViewModel>()
                .AddTransient<ListaArticoliViewModel>()
                .AddTransient<ArticoloViewModel>()

                .AddTransient<ClienteViewModel>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<ListaClientiViewModel>()

                .AddTransient<FornitoreViewModel>()
                .AddTransient<ListaFornitoriViewModel>()
                .AddTransient<FornitoriViewModel>()

                .AddTransient<CategoriaViewModel>();
            return serviceCollection;
        }
    }
}
