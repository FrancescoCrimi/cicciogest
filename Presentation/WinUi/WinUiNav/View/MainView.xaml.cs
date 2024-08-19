// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiBackend.ViewModel;
using CiccioGest.Presentation.WinUiNav.Services;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiNav.View
{
    public sealed partial class MainView : Page
    {
        public MainView(NavigationService navigationService,
                         MainViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = mainViewModel;
        }
    }
}
