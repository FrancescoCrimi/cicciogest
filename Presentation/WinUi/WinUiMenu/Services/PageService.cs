// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiBackend.Services;
using CiccioGest.Presentation.WinUiBackend.Views;

namespace CiccioGest.Presentation.WinUiMenu.Services
{
    public class PageService : PageServiceBase
    {
        public PageService()
        {
            Configure<DashboardViewModel, DashboardView>();
            Configure<ArticoliViewModel, ArticoliView>();
            Configure<ArticoloViewModel, ArticoloView>();
            Configure<CategoriaViewModel, CategoriaView>();
            Configure<ClienteViewModel, ClienteView>();
            Configure<ClientiViewModel, ClientiView>();
            Configure<FatturaViewModel, FatturaView>();
            Configure<FattureViewModel, FattureView>();
            Configure<FornitoreViewModel, FornitoreView>();
            Configure<FornitoriViewModel, FornitoriView>();
            Configure<SettingsViewModel, SettingsView>();
        }
    }
}
