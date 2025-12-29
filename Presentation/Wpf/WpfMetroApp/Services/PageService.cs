// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WpfBackend.Services;
using CiccioGest.Presentation.WpfMetroApp.Views;

namespace CiccioGest.Presentation.WpfMetroApp.Services
{
    public class PageService : PageServiceBase
    {
        public PageService()
        {
            Configure<ArticoliViewModel, ArticoliView>();
            Configure<ArticoloViewModel, ArticoloView>();
            Configure<CategoriaViewModel, CategoriaView>();
            Configure<ClienteViewModel, ClienteView>();
            Configure<ClientiViewModel, ClientiView>();
            //Configure<DashboardView>(ViewEnum.Dashboard);
            Configure<FatturaViewModel, FatturaView>();
            Configure<FattureViewModel, FattureView>();
            Configure<FornitoreViewModel, FornitoreView>();
            Configure<FornitoriViewModel, FornitoriView>();
            //Configure<SettingsView>(ViewEnum.Settings);
        }
    }
}