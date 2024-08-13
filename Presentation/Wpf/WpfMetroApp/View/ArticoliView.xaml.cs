// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModel;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public sealed partial class ArticoliView : UserControl, IDisposable
    {
        public ArticoliView(ArticoliViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public void Dispose()
        {
            ((IDisposable?)DataContext)?.Dispose();
            DataContext = null;
        }
    }
}
