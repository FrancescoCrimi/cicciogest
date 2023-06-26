// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WinUiNav.Services;
using CiccioGest.Presentation.WinUiNav.ViewModel;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiNav.View
{
    public sealed partial class ShellView : Page
    {
        public ShellView(NavigationService navigationService,
                         ShellViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = mainViewModel;
        }
    }
}
