// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application.Impl;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace CiccioGest.Presentation.UwpBackend
{
    public static class UwpBackendExtensions
    {
        public static IServiceCollection ConfigureUwpBackend(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .ConfigureApplication()
                .AddTransient<ShellViewModel>()
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
