// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiBackend.Contracts;
using CiccioGest.Presentation.WinUiBackend.View;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiccioGest.Presentation.WinUiNav.Services
{
    public class PageService
    {
        private readonly Dictionary<ViewEnum, Type> _pages = new Dictionary<ViewEnum, Type>();

        public PageService()
        {
            Configure<DashboardView>(ViewEnum.Dashboard);
            Configure<ArticoliView>(ViewEnum.Articoli);
            Configure<ArticoloView>(ViewEnum.Articolo);
            Configure<CategoriaView>(ViewEnum.Categoria);
            Configure<ClienteView>(ViewEnum.Cliente);
            Configure<ClientiView>(ViewEnum.Clienti);
            Configure<FatturaView>(ViewEnum.Fattura);
            Configure<FattureView>(ViewEnum.Fatture);
            Configure<FornitoreView>(ViewEnum.Fornitore);
            Configure<FornitoriView>(ViewEnum.Fornitori);
            Configure<ListaArticoliView>(ViewEnum.ListaArticoli);
            Configure<ListaClientiView>(ViewEnum.ListaClienti);
            Configure<ListaFattureView>(ViewEnum.ListaFatture);
            Configure<ListaFornitoriView>(ViewEnum.ListaFornitori);
            Configure<SettingsView>(ViewEnum.Settings);
        }

        public Type GetPageType(ViewEnum key)
        {
            Type pageType;
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
            where V : Page
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
