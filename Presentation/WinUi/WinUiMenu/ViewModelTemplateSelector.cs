// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiMenu
{
    public partial class ViewModelTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? ArticoliTemplate { get; set; }
        public DataTemplate? ArticoloTemplate { get; set; }
        public DataTemplate? CategoriaTemplate { get; set; }
        public DataTemplate? ClienteTemplate { get; set; }
        public DataTemplate? ClientiTemplate { get; set; }
        public DataTemplate? DashboardTemplate { get; set; }
        public DataTemplate? FatturaTemplate { get; set; }
        public DataTemplate? FattureTemplate { get; set; }
        public DataTemplate? FornitoreTemplate { get; set; }
        public DataTemplate? FornitoriTemplate { get; set; }
        public DataTemplate? SettingsTemplate { get; set; }

        protected override DataTemplate? SelectTemplateCore(object item)
        {
            return item switch
            {
                ArticoliViewModel => ArticoliTemplate,
                ArticoloViewModel => ArticoloTemplate,
                CategoriaViewModel => CategoriaTemplate,
                ClienteViewModel => ClienteTemplate,
                ClientiViewModel => ClientiTemplate,
                DashboardViewModel => DashboardTemplate,
                FatturaViewModel => FatturaTemplate,
                FattureViewModel => FattureTemplate,
                FornitoreViewModel => FornitoreTemplate,
                FornitoriViewModel => FornitoriTemplate,
                SettingsViewModel => SettingsTemplate,
                _ => base.SelectTemplateCore(item)
            };
        }
    }
}
