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

        private TaskCompletionSource<DialogResult<int>>? _currentDialogTcs;
        private ResultViewModelBase<int>? _currentDialogVm;

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
            if (_currentDialogVm != null)
            {
                CancelActiveResultPage();
                return;
            }
            GoBackInternal(emptyForwardStack);
        }

        private void GoBackInternal(bool emptyForwardStack = false)
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


        // -------------------------------
        // NAVIGAZIONE NORMALE 
        // -------------------------------
        public async Task Navigate<TVM>(object? parameter = null,
                                        bool clearNavigation = false) where TVM : ViewModelBase
        {
            if (_contentControl == null)
                throw new Exception("NavigationService must be Initialize before use it");

            var pageType = _pageService.GetPageType(typeof(TVM));
            if (_contentControl?.Content?.GetType() != pageType)
            {
                CancelActiveResultPage();
                var viewModel = _serviceProvider.GetRequiredService<TVM>();

                await NavigateTo(viewModel, parameter, clearNavigation);
            }
        }

        // -------------------------------
        // NAVIGAZIONE CON RISULTATO
        // -------------------------------
        public Task<DialogResult<int>> NavigateForResultAsync<TVM>() where TVM : ResultViewModelBase<int>
        {
            if (_contentControl == null)
                throw new Exception("NavigationService must be Initialize before use it");

            CancelActiveResultPage();

            var tcs = new TaskCompletionSource<DialogResult<int>>();
            var viewModel = _serviceProvider.GetRequiredService<TVM>();

            viewModel.CloseRequested = result =>
            {
                if (!tcs.Task.IsCompleted)
                    tcs.SetResult(result);
                if (result.Type == DialogResultType.Cancel)
                {
                    GoBackInternal();
                }
                _currentDialogTcs = null;
                _currentDialogVm = null;
            };

            _currentDialogTcs = tcs;
            _currentDialogVm = viewModel;

            _ = NavigateTo(viewModel);

            return tcs.Task;
        }

        private async Task NavigateTo<TVM>(TVM viewModel,
                                           object? parameter = null,
                                           bool clearNavigation = false)
        {
            // valorizzo ViewModel precedente
            var oldViewModel = (_contentControl?.Content as UserControl)?.DataContext as ViewModelBase;

            // 1. Notifica la pagina corrente che stiamo per lasciarla
            if (oldViewModel is INavigationAwareAsync oldAware)
            {
                var canLeave = await oldAware.OnNavigatingFromAsync();
                if (!canLeave)
                    return;

                await oldAware.OnNavigatedFromAsync();
            }

            // 2. Mostra la nuova pagina
            var pageType = _pageService.GetPageType(typeof(TVM));
            var view = (UserControl)Activator.CreateInstance(pageType)!;
            view.DataContext = viewModel;
            _contentControl!.Content = view;

            // 3. Notifica la nuova pagina che è stata navigata
            if (viewModel is INavigationAwareAsync newAware)
                await newAware.OnNavigatedToAsync(parameter);

            // 4. Gestione stack
            if (!clearNavigation)
            {
                // copia oldViewModel precedente nel BackStack
                // se oldViewModel è ResultViewModelBase
                if (oldViewModel != null && oldViewModel is not ResultViewModelBase<int>)
                    _backStack.Push(oldViewModel);
            }
            else
            {
                if (oldViewModel is IDisposable disposable)
                    disposable.Dispose();
                TerminateBackStack();
            }
            TerminateForwardStack();
            Navigated?.Invoke(this, new EventArgs());
        }

        private void CancelActiveResultPage()
        {
            if (_currentDialogVm == null || _currentDialogTcs == null)
                return;

            // chiude la pagina con risultato "Cancel"
            if (!_currentDialogTcs.Task.IsCompleted)
                _currentDialogTcs.SetResult(new DialogResult<int>(DialogResultType.Cancel, default));

            _currentDialogVm = null;
            _currentDialogTcs = null;
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
