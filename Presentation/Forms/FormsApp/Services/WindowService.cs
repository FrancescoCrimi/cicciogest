// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.FormsApp.Presenters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.FormsApp.Services
{
    public class WindowService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public WindowService(ILogger<WindowService> logger,
                             IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public async Task Show<TPresenter>(object? parameter = null)
            where TPresenter : PresenterBase
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter is IInitializable init && parameter != null)
                await init.InitializeAsync(parameter);

            presenter.Show();
        }

        public Task<int> ShowDialogAsync<TPresenter>(IWin32Window owner)
            where TPresenter : PresenterBase, IDialogResultProvider<int>
        {
            // Otteniamo il riferimento alla form principale (owner)
            Form? mainForm = owner as Form ?? System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault();

            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            var tcs = new TaskCompletionSource<int>();

            void OnValueSelected(object? s, int result)
            {
                presenter.ValueSelected -= OnValueSelected;
                presenter.Close();

                // Riabilita la form principale e riportala in primo piano
                if (mainForm != null)
                {
                    mainForm.Enabled = true;
                    mainForm.Activate();
                }
                tcs.TrySetResult(result);
            }
            presenter.ValueSelected += OnValueSelected;

            // --- SIMULAZIONE MODALE ---
            // Disabilita la form principale per impedire interazioni (comportamento modale)
            if (mainForm != null) mainForm.Enabled = false;

            // Mostra la form in modalità non bloccante
            presenter.Show(owner);

            return tcs.Task;
        }
    }
}
