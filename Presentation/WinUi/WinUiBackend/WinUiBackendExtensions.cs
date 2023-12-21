// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

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
                .AddTransient<ListaFornitoriViewModel>()
                .AddTransient<DashboardViewModel>()
                .AddTransient<SettingsViewModel>();
        }
    }
}
