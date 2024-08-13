 // Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WpfBackend.Services;
using CiccioGest.Presentation.Mvvm.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public sealed partial class MainView : Window, IDisposable
    {
        public MainView(MainViewModel shellViewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = shellViewModel;
            navigationService.Initialize(shellFrame);
        }

        public void Dispose()
        {
            ((IDisposable?)DataContext)?.Dispose();
            DataContext = null;
        }
    }
}
