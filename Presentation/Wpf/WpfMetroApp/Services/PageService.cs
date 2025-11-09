// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.WpfMetroApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.Services
{
    public class PageService : IPageService
    {
        private readonly Dictionary<ViewEnum, Type> _pages = new();

        public PageService()
        {
            Configure<ArticoliView>(ViewEnum.Articoli);
            Configure<ArticoloView>(ViewEnum.Articolo);
            Configure<CategoriaView>(ViewEnum.Categoria);
            Configure<ClienteView>(ViewEnum.Cliente);
            Configure<ClientiView>(ViewEnum.Clienti);
            //Configure<DashboardView>(ViewEnum.Dashboard);
            Configure<FatturaView>(ViewEnum.Fattura);
            Configure<FattureView>(ViewEnum.Fatture);
            Configure<FornitoreView>(ViewEnum.Fornitore);
            Configure<FornitoriView>(ViewEnum.Fornitori);
            //Configure<SettingsView>(ViewEnum.Settings);
        }

        public Type GetPageType(ViewEnum key)
        {
            Type? pageType;
            lock (_pages)
            {
                if (!_pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }
            return pageType;
        }

        private void Configure<V>(ViewEnum key)
            where V : UserControl
        {
            lock (_pages)
            {
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(V);
                if (_pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
                }

                _pages.Add(key, type);
            }
        }
    }
}