﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WpfApp.View;
using CiccioGest.Presentation.Mvvm.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using CiccioGest.Presentation.WpfBackend.Services;

namespace CiccioGest.Presentation.WpfApp.Services
{
    public class PageService : IPageService
    {
        private readonly Dictionary<string, Type> pages = new();

        public PageService()
        {
            Configure<ArticoliViewModel, ArticoliView>();
            Configure<ArticoloViewModel, ArticoloView>();
            Configure<CategoriaViewModel, CategoriaView>();
            Configure<ClienteViewModel, ClienteView>();
            Configure<ClientiViewModel, ClientiView>();
            Configure<FatturaViewModel, FatturaView>();
            Configure<FattureViewModel, FattureView>();
            Configure<FornitoreViewModel, FornitoreView>();
            Configure<FornitoriViewModel, FornitoriView>();
        }

        public Type GetPageType(string key)
        {
            Type? pageType;
            lock (pages)
            {
                if (!pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }
            return pageType;
        }

        private void Configure<VM, V>()
            where VM : ObservableObject
            where V : UserControl
        {
            lock (pages)
            {
                var key = typeof(VM).Name;
                if (pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }

                var type = typeof(V);
                if (pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {pages.First(p => p.Value == type).Key}");
                }

                pages.Add(key, type);
            }
        }
    }
}