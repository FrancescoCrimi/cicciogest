// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application.Impl;
using CiccioGest.Presentation.Mvvm.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm
{
    public static class ConfigureExtensions
    {
        public static IServiceCollection ConfigureMvvm(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .ConfigureApplication()
                .AddTransient<ArticoloViewModel>()
                .AddTransient<ArticoliViewModel>()
                .AddTransient<CategoriaViewModel>()
                .AddTransient<ClienteViewModel>()
                .AddTransient<ClientiViewModel>()
                .AddTransient<DashboardViewModel>()
                .AddTransient<FatturaViewModel>()
                .AddTransient<FattureViewModel>()
                .AddTransient<FornitoreViewModel>()
                .AddTransient<FornitoriViewModel>()
                .AddTransient<MainViewModel>();
            return serviceCollection;
        }
    }
}
