// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ListaFattureView : Page
    {
        public ListaFattureView(ListaFattureViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
