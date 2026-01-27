// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiBackend.Services
{
    public sealed class NavigationService : INavigationService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<ViewModelBase> _forwardStack;
        private readonly Stack<ViewModelBase> _backStack;

        private TaskCompletionSource<DialogResult<int>>? _currentDialogTcs;
        private ResultViewModelBase<int>? _currentDialogVm;

        public event EventHandler? Navigated;
        public ViewModelBase? Current { get; private set; }

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _forwardStack = new Stack<ViewModelBase>();
            _backStack = new Stack<ViewModelBase>();
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public bool CanGoBack => _backStack.Count != 0;

        public bool CanGoForward => _forwardStack.Count != 0;

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

                //var forwardVM = (ViewModelBase)((UserControl)_contentControl!.Content).DataContext;
                var forwardVM = Current!;   // New Impl
                _forwardStack.Push(forwardVM);

                var backVM = _backStack.Peek();
                //var viewType = _pageService.GetPageType(backVM.GetType());
                //var view = (UserControl)Activator.CreateInstance(viewType)!;
                //view.DataContext = backVM;
                //_contentControl!.Content = view;
                Current = backVM;           // New Impl

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
                //var backVM = (ViewModelBase)((UserControl)_contentControl!.Content).DataContext;
                var backVM = Current!;      // New Impl
                _backStack.Push(backVM);

                var forwardVM = _forwardStack.Peek();
                //var viewType = _pageService.GetPageType(forwardVM.GetType());
                //var view = (UserControl)Activator.CreateInstance(viewType)!;
                //view.DataContext = forwardVM;
                //_contentControl.Content = view;
                Current = forwardVM;        // New Impl

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
            //if (_contentControl == null)
            //    throw new Exception("NavigationService must be Initialize before use it");

            //var pageType = _pageService.GetPageType(typeof(TVM));
            //if (_contentControl?.Content?.GetType() != pageType)
            if (Current?.GetType() != typeof(TVM)) // New Impl
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
            //if (_contentControl == null)
            //    throw new Exception("NavigationService must be Initialize before use it");

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
                                           bool clearNavigation = false) where TVM : ViewModelBase
        {
            // valorizzo ViewModel precedente
            //var oldViewModel = (_contentControl?.Content as UserControl)?.DataContext as ViewModelBase;
            var oldViewModel = Current; // New Impl

            // 1. Notifica la pagina corrente che stiamo per lasciarla
            if (oldViewModel is INavigationAwareAsync oldAware)
            {
                var canLeave = await oldAware.OnNavigatingFromAsync();
                if (!canLeave)
                    return;

                await oldAware.OnNavigatedFromAsync();
            }

            // 2. Mostra la nuova pagina
            //var pageType = _pageService.GetPageType(typeof(TVM));
            //var view = (UserControl)Activator.CreateInstance(pageType)!;
            //view.DataContext = viewModel;
            //_contentControl!.Content = view;
            Current = viewModel; // New Impl

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
