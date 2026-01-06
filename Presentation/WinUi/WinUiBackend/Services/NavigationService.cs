// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiBackend.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPageService _pageService;
        private readonly Stack<ViewModelBase> _forwardStack;
        private readonly Stack<ViewModelBase> _backStack;
        private ContentControl? _contentControl;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceProvider serviceProvider,
                                 IPageService pageService)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _pageService = pageService;
            _forwardStack = new Stack<ViewModelBase>();
            _backStack = new Stack<ViewModelBase>();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public bool CanGoBack => _backStack.Count != 0;

        public bool CanGoForward => _forwardStack.Count != 0;

        public event EventHandler? Navigated;

        public void Initialize(ContentControl contentControl)
        {
            ArgumentNullException.ThrowIfNull(contentControl);

            if (_contentControl == null)
            {
                _contentControl = contentControl;
            }
            else
            {
                throw new Exception("NavigationService already initialized");
            }
        }

        public void GoBack(bool emptyForwardStack = false)
        {
            if (_backStack.Count != 0)
            {

                var forwardvm = (ViewModelBase)((UserControl)_contentControl!.Content).DataContext;
                _forwardStack.Push(forwardvm);

                var backvm = _backStack.Peek();
                var viewType = _pageService.GetPageType(backvm.GetType());
                var view = (UserControl)Activator.CreateInstance(viewType)!;
                view.DataContext = backvm;
                _contentControl!.Content = view;

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
                var backvm = (ViewModelBase)((UserControl)_contentControl!.Content).DataContext;
                _backStack.Push(backvm);

                var forwardvm = _forwardStack.Peek();
                var viewType = _pageService.GetPageType(forwardvm.GetType());
                var view = (UserControl)Activator.CreateInstance(viewType)!;
                view.DataContext = forwardvm;
                _contentControl.Content = view;

                _forwardStack.Pop();
                if (emptyBackStack)
                {
                    TerminateBackStack();
                }
                Navigated?.Invoke(this, new EventArgs());
            }
        }

        public void Navigate<TVM>(object? parameter = null, bool clearNavigation = false) where TVM : ViewModelBase
        {
            if (_contentControl == null)
                throw new Exception("NavigationService must be Initialize before use it");
            var pageType = _pageService.GetPageType(typeof(TVM));
            if (_contentControl?.Content?.GetType() != pageType)
            {
                var viewModel = _serviceProvider.GetRequiredService<TVM>();

                // inizializza ViewModel
                if (viewModel is IViewModel iViewModel)
                    iViewModel.Initialize(parameter);

                // valorizzo ViewModel precedente
                var oldViewModel = (_contentControl.Content as UserControl)?.DataContext as ViewModelBase;

                // visualizza nuova pagina
                var view = (UserControl)Activator.CreateInstance(pageType)!;
                view.DataContext = viewModel;
                _contentControl!.Content = view;

                if (!clearNavigation)
                {
                    // copia pagina precedente nel backstack
                    if (oldViewModel != null)
                        _backStack.Push(oldViewModel);
                }
                else
                {
                    if (oldViewModel != null)
                    {
                        if (oldViewModel is IDisposable disposable)
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

        public Task<int> NavigateDialogAsync<TVM>() where TVM : DialogViewModelBase<int>
        {
            if (_contentControl == null)
                throw new Exception("NavigationService must be Initialize before use it");

            var tcs = new TaskCompletionSource<int>();
            var viewModel = _serviceProvider.GetRequiredService<TVM>();

            void OnCloseDialog(object? sender, int e)
            {
                viewModel.CloseDialogEvent -= OnCloseDialog;
                tcs.SetResult(e);
            }
            viewModel.CloseDialogEvent += OnCloseDialog;

            // valorizzo ViewModel precedente
            var oldViewModel = (_contentControl.Content as UserControl)?.DataContext as ViewModelBase;

            var viewType = _pageService.GetPageType(typeof(TVM));
            var view = (UserControl)Activator.CreateInstance(viewType)!;
            view.DataContext = viewModel;

            // visualizza nuova pagina
            _contentControl!.Content = view;

            // copia pagina precedente nel backstack
            if (oldViewModel != null)
            {
                _backStack.Push(oldViewModel);
            }
            TerminateForwardStack();
            Navigated?.Invoke(this, new EventArgs());
            return tcs.Task;
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
    }
}
