// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiccioGest.Presentation.WinUiBackend.Services
{
    public abstract class PageServiceBase : IPageService
    {
        private readonly Dictionary<Type, Type> _pages = [];

        public Type GetPageType(Type viewModelType)
        {
            Type? viewType;
            lock (_pages)
            {
                if (!_pages.Any(p => p.Key == viewModelType))
                {
                    throw new ArgumentException($"Page not found for ViewModel: {viewModelType}. Did you forget to call PageService.Configure?");
                }
                viewType = _pages.First(p => p.Key == viewModelType).Value;
            }
            return viewType!;
        }

        protected void Configure<VM, V>()
            where VM : ViewModelBase
            where V : UserControl
        {
            lock (_pages)
            {
                var viewModelType = typeof(VM);
                var viewType = typeof(V);
                if (_pages.Any(p => p.Key == viewModelType))
                {
                    throw new ArgumentException($"This view model is already configured with view type {_pages.First(p => p.Key == viewModelType).Value}");
                }
                if (_pages.Any(p => p.Value == viewType))
                {
                    throw new ArgumentException($"This view type is already configured with view model {_pages.First(p => p.Value == viewType).Key}");
                }
                _pages.Add(viewModelType, viewType);
            }
        }
    }
}
