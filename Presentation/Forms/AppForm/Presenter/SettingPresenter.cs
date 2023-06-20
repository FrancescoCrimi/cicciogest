// Copyright (c) 2023 Francesco Crimi
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class SettingPresenter : PresenterBase, IDisposable
    {
        private readonly ILogger<SettingPresenter> logger;
        private readonly ISettingView view;
        private readonly IServiceProvider serviceProvider;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public SettingPresenter(ILogger<SettingPresenter> logger,
                                ISettingView view,
                                IServiceProvider serviceProvider,
                                IServiceScopeFactory serviceScopeFactory)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.serviceProvider = serviceProvider;
            this.serviceScopeFactory = serviceScopeFactory;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            view.CreaDatabaseEvent += View_CreaDatabaseEvent;
            view.VerificaDatabaseEvent += View_VerificaDatabaseEvent;
            view.PopolaDatabaseEvent += View_PopolaDatabaseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        private void View_LoadEvent(object sender, EventArgs e)
        {
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
        }

        private void View_CreaDatabaseEvent(object sender, EventArgs e)
        {
            try
            {
                var uowf = serviceProvider.GetService<IUnitOfWorkFactory>();
                uowf.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void View_VerificaDatabaseEvent(object sender, EventArgs e)
        {
            try
            {
                var uowf = serviceProvider.GetService<IUnitOfWorkFactory>();
                uowf.VerifyDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void View_PopolaDatabaseEvent(object sender, EventArgs e)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var sett = scope.ServiceProvider.GetService<ISettingService>();
                await sett.LoadSampleData();
                MessageBox.Show("Eseguito con successo");
            }
        }

        public void Dispose()
        {
        }
    }
}
