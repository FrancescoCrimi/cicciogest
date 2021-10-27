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
                .AddTransient<FattureListViewModel>()

                .AddTransient<ArticoliViewModel>()
                .AddTransient<ArticoliListViewModel>()
                .AddTransient<ArticoloViewModel>()

                .AddTransient<ClienteViewModel>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<ClientiListViewModel>()

                .AddTransient<FornitoreViewModel>()
                .AddTransient<FornitoriListViewModel>()
                .AddTransient<FornitoriViewModel>()

                .AddTransient<CategoriaViewModel>();
            return serviceCollection;
        }
    }
}
