// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WpfApp.Views;
using CiccioGest.Presentation.WpfBackend.Services;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.WpfApp.Services
{
    public class PageService : PageServiceBase
    {
        private readonly Dictionary<Type, Type> _pages = [];

        public PageService()
        {
            Configure<ArticoliViewModel, ArticoliView>();
            Configure<ArticoloViewModel, ArticoloView>();
            Configure<CategoriaViewModel, CategoriaView>();
            Configure<ClienteViewModel, ClienteView>();
            Configure<ClientiViewModel, ClientiView>();
            Configure<DashboardViewModel, DashboardView>();
            Configure<FatturaViewModel, FatturaView>();
            Configure<FattureViewModel, FattureView>();
            Configure<FornitoreViewModel, FornitoreView>();
            Configure<FornitoriViewModel, FornitoriView>();
            Configure<SettingsViewModel, SettingsView>();
        }
    }
}
