// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiBackend.Views
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
