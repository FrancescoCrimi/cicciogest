using CiccioGest.Presentation.UwpApp.View;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.Services
{
    public class PageService
    {
        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        public PageService()
        {
            Configure<MainViewModel, MainView>();
            Configure<ArticoliViewModel, ArticoliView>();
            Configure<ArticoliListViewModel, ArticoliDialogView>();
            Configure<ArticoloViewModel, ArticoloView>();
            Configure<CategoriaViewModel, CategoriaView>();
            Configure<ClienteViewModel, ClienteView>();
            Configure<ClientiViewModel, ClientiView>();
            Configure<ClientiListViewModel, ClientiDialogView>();
            Configure<FatturaViewModel, FatturaView>();
            Configure<FattureViewModel, FattureView>();
            Configure<FattureListViewModel, FattureDialogView>();
        }

        public Type GetPageType(string key)
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

        private void Configure<VM, V>()
            where VM : ObservableObject
            where V : Page
        {
            lock (_pages)
            {
                var key = typeof(VM).Name;
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
