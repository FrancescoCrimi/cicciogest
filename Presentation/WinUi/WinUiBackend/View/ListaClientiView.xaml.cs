// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiBackend.View
{
    public sealed partial class ListaClientiView : Page
    {
        public ListaClientiView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ListaClientiViewModel>();
        }
    }
}
