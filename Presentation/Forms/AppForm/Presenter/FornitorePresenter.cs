// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.View;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class FornitorePresenter : PresenterBase, IDisposable
    {
        private readonly ILogger<FornitorePresenter> logger;
        private readonly IFornitoreView view;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly WindowService windowService;

        public FornitorePresenter(ILogger<FornitorePresenter> logger,
                                  IFornitoreView view,
                                  IClientiFornitoriService clientiFornitoriService,
                                  WindowService windowService)
            : base(view)
        {
            this.logger = logger;
            this.view = view;
            this.clientiFornitoriService = clientiFornitoriService;
            this.windowService = windowService;
            view.LoadEvent += View_LoadEvent;
            view.CloseEvent += View_CloseEvent;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        #region Metodi Pubblici

        public void NuovoFornitore()
            => view.MostraFornitore(new Fornitore());

        public async void ApriFornitore(int idFornitore)
            => view.MostraFornitore(await clientiFornitoriService.GetFornitore(idFornitore));

        #endregion

        #region Gestione eventi

        private void View_LoadEvent(object sender, EventArgs e)
        {
            view.ApriFornitore += View_ApriFornitore;
            view.NuovoFornitore += View_NuovoFornitore;
            view.SalvaFornitore += View_SalvaFornitore;
        }

        private void View_CloseEvent(object sender, EventArgs e)
        {
            view.ApriFornitore -= View_ApriFornitore;
            view.NuovoFornitore -= View_NuovoFornitore;
            view.SalvaFornitore -= View_SalvaFornitore;
        }


        private void View_SalvaFornitore(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_NuovoFornitore(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_ApriFornitore(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            view.LoadEvent -= View_LoadEvent;
            view.CloseEvent -= View_CloseEvent;
        }
    }
}
