// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public sealed class SettingPresenter : PresenterBase
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private ISettingView _view;

        public SettingPresenter(ILogger<SettingPresenter> logger,
                                IServiceProvider serviceProvider,
                                IServiceScopeFactory serviceScopeFactory,
                                ISettingView view)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _serviceProvider = serviceProvider;
            _serviceScopeFactory = serviceScopeFactory;
            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.CreaDatabaseRequested += View_CreaDatabaseEvent;
            _view.VerificaDatabaseRequested += View_VerificaDatabaseEvent;
            _view.PopolaDatabaseRequested += View_PopolaDatabaseEvent;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void Run()
        {
            System.Windows.Forms.Application.Run((Form)_view);
        }

        #region Event Handlers

        private void OnLoad(object? sender, EventArgs e)
        {
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
        }

        private void View_CreaDatabaseEvent(object? sender, EventArgs e)
        {
            try
            {
                var uowf = _serviceProvider.GetService<IUnitOfWorkFactory>();
                uowf?.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void View_VerificaDatabaseEvent(object? sender, EventArgs e)
        {
            try
            {
                var uowf = _serviceProvider.GetService<IUnitOfWorkFactory>();
                uowf?.VerifyDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void View_PopolaDatabaseEvent(object? sender, EventArgs e)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var sett = scope.ServiceProvider.GetRequiredService<ISettingService>();
                await sett.LoadSampleData();
                MessageBox.Show("Eseguito con successo");
            }
        }

        #endregion

        public override void Dispose()
        {
            base.Dispose();
            _view.Load -= OnLoad;
            _view.FormClosing -= OnFormClosing;
            _view.CreaDatabaseRequested -= View_CreaDatabaseEvent;
            _view.VerificaDatabaseRequested -= View_VerificaDatabaseEvent;
            _view.PopolaDatabaseRequested -= View_PopolaDatabaseEvent;
            _view = null!;
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());

        }
    }
}
