﻿using CiccioGest.Presentation.WpfBackend.ViewModel;
using CiccioGest.Presentation.WpfMetroApp.View;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.Services
{
    public class PageService
    {
        private readonly Dictionary<string, Type> pages = new Dictionary<string, Type>();

        public PageService()
        {
            //Configure<MainViewModel, MainPage>();
            Configure<ArticoliViewModel, ArticoliView>();
            Configure<ArticoloViewModel, ArticoloView>();
            Configure<CategoriaViewModel, CategoriaView>();
            Configure<ClienteViewModel, ClienteView>();
            Configure<ClientiViewModel, ClientiView>();
            Configure<FatturaViewModel, FatturaView>();
            Configure<FattureViewModel, FattureView>();
            Configure<FornitoreViewModel, FornitoreView>();
            Configure<FornitoriViewModel, FornitoriView>();
            Configure<ListaArticoliViewModel, ListaArticoliView>();
            Configure<ListaClientiViewModel, ListaClientiView>();
            Configure<ListaFattureViewModel, ListaFattureView>();
            Configure<ListaFornitoriViewModel, ListaFornitoriView>();
        }

        public Type GetPageType(string key)
        {
            Type pageType;
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
            where V : Page
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