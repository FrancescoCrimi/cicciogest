// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.Views
{
    public sealed partial class FatturaView : UserControl, IDisposable
    {
        public FatturaView(FatturaViewModel fatturaViewModel)
        {
            DataContext = fatturaViewModel;
            InitializeComponent();
        }

        public void Dispose()
        {
            ((IDisposable?)DataContext)?.Dispose();
            DataContext = null;
        }
    }
}
