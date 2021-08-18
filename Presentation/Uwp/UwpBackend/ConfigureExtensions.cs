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
                .AddTransient<FatturaViewModel>()
                .AddTransient<ArticoloViewModel>()
                .AddTransient<CategoriaViewModel>()
                .AddTransient<FattureViewModel>()
                .AddTransient<ArticoliViewModel>()
                .AddTransient<ClientiViewModel>();
            return serviceCollection;
        }
    }
}
