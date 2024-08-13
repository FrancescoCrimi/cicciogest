// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfBackend.Services
{
    public sealed class NavigationService : INavigationService, IDisposable
    {
        public event EventHandler? Navigated;

        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPageService _pageService;
        private readonly Stack<UserControl> _forwardStack;
        private readonly Stack<UserControl> _backStack;
        private ContentControl? _contentControl;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceProvider serviceProvider,
                                 IPageService pageService)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _pageService = pageService;
            _forwardStack = new Stack<UserControl>();
            _backStack = new Stack<UserControl>();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(ContentControl contentControl)
        {
            if (contentControl is null)
            {
                throw new ArgumentNullException(nameof(contentControl));
            }

            if (_contentControl == null)
            {
                _contentControl = contentControl;
            }
            else
            {
                throw new Exception("NavigationService already initialized");
            }
        }

        public bool CanGoBack => _backStack.Count != 0;

        public bool CanGoForward => _forwardStack.Count != 0;

        public void GoBack(bool emptyForwardStack = false)
        {
            if (_backStack.Count != 0)
            {
                _forwardStack.Push((UserControl)_contentControl!.Content);
                _contentControl.Content = _backStack.Peek();
                _backStack.Pop();
                if (emptyForwardStack)
                {
                    TerminateForwardStack();
                }
                Navigated?.Invoke(this, new EventArgs());
            }
        }

        public void GoForward(bool emptyBackStack = false)
        {
            if (_forwardStack.Count != 0)
            {
                _backStack.Push((UserControl)_contentControl!.Content);
                _contentControl.Content = _forwardStack.Peek();
                _forwardStack.Pop();
                if (emptyBackStack)
                {
                    TerminateBackStack();
                }
                Navigated?.Invoke(this, new EventArgs());
            }
        }


        public void Navigate(Type pageType,
                             bool clearNavigation = true)
        {
            if (_contentControl == null)
            {
                throw new Exception("NavigationService must be Initialize before use it");
            }

            if (_contentControl?.Content?.GetType() != pageType)
            {
                var page = _serviceProvider.GetRequiredService(pageType);

                // valorizzo pagina precedente
                var oldPage = _contentControl?.Content;

                // visualizza nuova pagina
                _contentControl!.Content = page;

                if (!clearNavigation)
                {
                    // copia pagina precedente nel backstack
                    if (oldPage != null)
                    {
                        _backStack.Push((UserControl)oldPage);
                    }
                }
                else
                {
                    if (oldPage != null)
                    {
                        if (oldPage is IDisposable disposable)
                        {
                            disposable.Dispose();
                        }
                    }
                    TerminateBackStack();
                }
                TerminateForwardStack();
                Navigated?.Invoke(this, new EventArgs());
            }
        }

        public void Navigate(string key,
                             bool clearNavigation = true)
        {
            var pageType = _pageService.GetPageType(key);
            Navigate(pageType, clearNavigation);
        }

        /// <summary>
        /// termina tutte le pagine contenute nel backstack
        /// e azzera lo stack
        /// </summary>
        private void TerminateBackStack()
        {
            foreach (var item in _backStack)
            {
                if (item is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            _backStack.Clear();
        }

        /// <summary>
        /// termina tutte le pagine contenute nel forwardstack
        /// e azzera lo stack
        /// </summary>
        private void TerminateForwardStack()
        {
            foreach (var item in _forwardStack)
            {
                if (item is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            _forwardStack.Clear();
        }

        public void Dispose()
        {
            if (_contentControl?.Content != null)
            {
                if (_contentControl.Content is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            _contentControl = null;
            TerminateBackStack();
            TerminateForwardStack();
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
