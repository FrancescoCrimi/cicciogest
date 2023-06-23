﻿// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.UwpApp.View;
using CiccioGest.Presentation.UwpBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.Services
{
    public class PageService
    {
        private readonly Dictionary<Views, Type> _pages = new Dictionary<Views, Type>();

        public PageService()
        {
            Configure<DashboardView>(Views.Dashboard);
            Configure<ArticoliView>(Views.Articoli);
            Configure<ArticoloView>(Views.Articolo);
            Configure<CategoriaView>(Views.Categoria);
            Configure<ClienteView>(Views.Cliente);
            Configure<ClientiView>(Views.Clienti);
            Configure<FatturaView>(Views.Fattura);
            Configure<FattureView>(Views.Fatture);
            Configure<FornitoreView>(Views.Fornitore);
            Configure<FornitoriView>(Views.Fornitori);
            Configure<ListaArticoliView>(Views.ListaArticoli);
            Configure<ListaClientiView>(Views.ListaClienti);
            Configure<ListaFattureView>(Views.ListaFatture);
            Configure<ListaFornitoriView>(Views.ListaFornitori);
        }

        public Type GetPageType(Views key)
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

        private void Configure<V>(Views key)
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
