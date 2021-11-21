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
            return serviceCollection;
        }
    }
}
