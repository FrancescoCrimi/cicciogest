// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class CategoriaView : Page
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
    }
}
