// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModel;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public sealed partial class CategoriaView : UserControl, IDisposable
    {
        public CategoriaView(CategoriaViewModel categoriaViewModel)
        {
            InitializeComponent();
            DataContext = categoriaViewModel;
        }

        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void ListView_MouseDoubleClick_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        public void Dispose()
        {
            ((IDisposable?)DataContext)?.Dispose();
            DataContext = null;
        }
    }
}
