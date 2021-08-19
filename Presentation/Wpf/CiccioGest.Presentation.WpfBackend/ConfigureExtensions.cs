﻿using CiccioGest.Application.Impl;
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
                .AddTransient<ShellViewModel>()
                .AddTransient<HomeViewModel>()

                .AddTransient<FatturaViewModel>()
                .AddTransient<FattureViewModel>()
                .AddTransient<FattureDialogViewModel>()

                .AddTransient<ArticoliViewModel>()
                .AddTransient<ArticoliDialogViewModel>()
                .AddTransient<ArticoloViewModel>()

                .AddTransient<ClienteViewModel>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<ClientiDialogViewModel>()
                .AddTransient<CategoriaViewModel>()

                ;
            return serviceCollection;
        }
    }
}
