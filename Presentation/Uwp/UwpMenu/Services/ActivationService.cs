// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.UwpMenu.Activation;
using CiccioGest.Presentation.UwpMenu.View;
using CommunityToolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpMenu.Services
{
    internal class ActivationService
    {
        private readonly ActivationHandler<IActivatedEventArgs> _defaultHandler;
        private readonly IEnumerable<IActivationHandler> _activationHandlers;
        private object _lastActivationArgs;

        public ActivationService(ActivationHandler<IActivatedEventArgs> defaultHandler,
                                 IEnumerable<IActivationHandler> activationHandlers)
        {
            _defaultHandler = defaultHandler;
            _activationHandlers = activationHandlers;
        }

        public async Task ActivateAsync(object activationArgs)
        {
            if (IsInteractive(activationArgs))
            {
                // Initialize services that you need before app activation
                // take into account that the splash screen is shown while this code runs.
                await InitializeAsync();

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (Window.Current.Content == null)
                {
                    // Create a Shell or Frame to act as the navigation context
                    UIElement shell = Ioc.Default.GetService<ShellView>();
                    Window.Current.Content = shell ?? new Frame();
                }
            }

            // Depending on activationArgs one of ActivationHandlers or DefaultActivationHandler
            // will navigate to the first page
            await HandleActivationAsync(activationArgs);
            _lastActivationArgs = activationArgs;

            if (IsInteractive(activationArgs))
            {
                // Ensure the current window is active
                Window.Current.Activate();

                // Tasks after activation
                await StartupAsync();
            }
        }

        private async Task InitializeAsync()
        {
            //await ThemeSelectorService.InitializeAsync().ConfigureAwait(false);
            //await WindowManagerService.Current.InitializeAsync();
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync(object activationArgs)
        {
            var activationHandler = _activationHandlers
                .FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (IsInteractive(activationArgs))
            {
                if (_defaultHandler.CanHandle(activationArgs))
                {
                    await _defaultHandler.HandleAsync(activationArgs);
                }
            }
        }

        private async Task StartupAsync()
        {
            //await ThemeSelectorService.SetRequestedThemeAsync();
            await Task.CompletedTask;
        }

        private bool IsInteractive(object args)
        {
            return args is IActivatedEventArgs;
        }
    }
}
