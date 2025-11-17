using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.Services
{
    public interface IDialogResult<TResult>
    {
        // Evento che il VM deve sollevare per chiudere il dialog con il risultato (null = annullato)
        event EventHandler<TResult?>? RequestClose;
    }

    public interface IWindowDialogService
    {
        // Mostra il dialog per il ViewModel TViewModel e restituisce il risultato TResult (null = annullato).
        Task<TResult?> ShowDialogAsync<TViewModel, TResult>(CancellationToken cancellationToken = default)
            where TViewModel : class, IDialogResult<TResult>;
    }


    public class WindowDialogService : IWindowDialogService
    {
        private readonly IServiceProvider _provider;
        private readonly Window? _owner;
        Window? dialogWindow = null;

        public WindowDialogService(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _owner = System.Windows.Application.Current?.MainWindow;
        }

        public Task<TResult?> ShowDialogAsync<TViewModel, TResult>(CancellationToken cancellationToken = default)
            where TViewModel : class, IDialogResult<TResult>
        {
            // Caller must be on UI thread. Fails fast if not.
            if (!System.Windows.Application.Current?.Dispatcher.CheckAccess() ?? true)
                throw new InvalidOperationException("WindowDialogService.ShowDialogAsync must be called on the UI thread.");

            var tcs = new TaskCompletionSource<TResult?>(TaskCreationOptions.RunContinuationsAsynchronously);

            // Resolve VM from DI
            var vm = ActivatorUtilities.CreateInstance<TViewModel>(_provider);
            void OnRequestClose(object? s, TResult? result)
            {
                try { vm.RequestClose -= OnRequestClose; } catch { }
                // Close window (will cause ShowDialog to return)
                try { dialogWindow?.Close(); } catch { }
                tcs.TrySetResult(result);
            }

            vm.RequestClose += OnRequestClose;


            // Create window, set DataContext, show dialog (blocks UI thread until closed)
            dialogWindow = new CiccioGest.Presentation.WpfApp.Views.DialogWindow
            {
                Owner = _owner,
                DataContext = vm
            };

            //// Optionally set window Title from VM if it exposes one
            //if (vm is IHaveDialogTitle titled && !string.IsNullOrWhiteSpace(titled.DialogTitle))
            //    dialogWindow.Title = titled.DialogTitle;

            // Cancellation: if token cancels before user action, unsubscribe and close window
            if (cancellationToken != default)
            {
                cancellationToken.Register(() =>
                {
                    try
                    {
                        vm.RequestClose -= OnRequestClose;
                    }
                    catch { }
                    try { dialogWindow?.Close(); } catch { }
                    tcs.TrySetCanceled();
                });
            }

            // ShowDialog on UI thread — caller must be on UI thread
            dialogWindow.ShowDialog();

            // By this point tcs should be completed by OnRequestClose (or cancellation)
            return tcs.Task;
        }
    }
}
