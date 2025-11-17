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
    public sealed partial class ClienteView : UserControl, IDisposable
    {
        public ClienteView(ClienteViewModel clienteViewModel)
        {
            InitializeComponent();
            DataContext = clienteViewModel;
        }

        public void Dispose()
        {
            ((IDisposable?)DataContext)?.Dispose();
            DataContext = null;
        }
    }
}
