using CiccioGest.Application.Impl;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CiccioGest.Presentation.UwpBackend
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureUwpBackend(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .ConfigureApplication()
                .AddTransient<MainViewModel>()
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
