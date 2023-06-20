// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WpfApp.Services;
using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class MainView : Window
    {
        public MainView(MainViewModel shellViewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = shellViewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
