// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiApp2.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp2.View
{
    public sealed partial class DashboardView : Page
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<DashboardViewModel>();
        }
    }
}
