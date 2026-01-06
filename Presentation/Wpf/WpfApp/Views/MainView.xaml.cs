// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WpfBackend.Services;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.Views
{
    public sealed partial class MainView : Window
    {
        public MainView(MainViewModel shellViewModel,
                        NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = shellViewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
