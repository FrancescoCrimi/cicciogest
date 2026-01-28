// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.Services
{
    internal sealed class NavigationService : INavigationService, IDisposable
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
                var forwardVM = Current;
                if (forwardVM != null)
                    _forwardStack.Push(forwardVM);

                var backVM = _backStack.Pop();
                Current = backVM;

                if (emptyForwardStack)
                    TerminateForwardStack();

                Navigated?.Invoke(this, new EventArgs());
            }
        }

        public void GoForward(bool emptyBackStack = false)
        {
            if (_forwardStack.Count != 0)
            {
                var backVM = Current;
                if (backVM != null)
                    _backStack.Push(backVM);

                var forwardVM = _forwardStack.Pop();
                Current = forwardVM;

                if (emptyBackStack)
                    TerminateBackStack();

                Navigated?.Invoke(this, new EventArgs());
            }
        }


        // -------------------------------
        // NAVIGAZIONE NORMALE 
        // -------------------------------
        public async Task Navigate<TVM>(object? parameter = null,
                                        bool clearNavigation = false) where TVM : ViewModelBase
        {
            if (Current?.GetType() != typeof(TVM))
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
            var oldViewModel = Current;

            // 1. Notifica la pagina corrente che stiamo per lasciarla
            if (oldViewModel is INavigationAwareAsync oldAware)
            {
                var canLeave = await oldAware.OnNavigatingFromAsync();
                if (!canLeave)
                    return;

                await oldAware.OnNavigatedFromAsync();
            }

            // 2. Mostra la nuova pagina
            Current = viewModel;

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
        /// termina tutte le pagine contenute nel backStack
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
        /// termina tutte le pagine contenute nel forwardStack
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
            if (Current != null && Current is IDisposable disposable)
                disposable.Dispose();

            Current = null;
            TerminateBackStack();
            TerminateForwardStack();
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
