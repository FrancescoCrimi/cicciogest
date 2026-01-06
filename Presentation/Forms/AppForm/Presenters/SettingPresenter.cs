// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public sealed class SettingPresenter : PresenterBase
    {
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        private ISettingView _view;
        private bool _disposedValue;

        public SettingPresenter(ILogger<SettingPresenter> logger,
                                ISettingService settingService,
                                ISettingView view)
            : base(view)
        {
            _logger = logger;
            _view = view;
            _settingService = settingService;

            _view.Load += OnLoad;
            _view.FormClosing += OnFormClosing;
            _view.CreaDatabaseRequested += View_CreaDatabaseEvent;
            _view.VerificaDatabaseRequested += View_VerificaDatabaseEvent;
            _view.PopolaDatabaseRequested += View_PopolaDatabaseEvent;

            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());

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

        private async void View_CreaDatabaseEvent(object? sender, EventArgs e)
        {
            try
            {
                await _settingService.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void View_VerificaDatabaseEvent(object? sender, EventArgs e)
        {
            try
            {
                await _settingService.VerifyDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void View_PopolaDatabaseEvent(object? sender, EventArgs e)
        {
            await _settingService.LoadSampleData();
            MessageBox.Show("Eseguito con successo");
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _view.Load -= OnLoad;
                    _view.FormClosing -= OnFormClosing;
                    _view.CreaDatabaseRequested -= View_CreaDatabaseEvent;
                    _view.VerificaDatabaseRequested -= View_VerificaDatabaseEvent;
                    _view.PopolaDatabaseRequested -= View_PopolaDatabaseEvent;
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                _view = null!;
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
