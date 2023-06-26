// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.UwpMenu.Services;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpMenu.View
{
    public sealed partial class ShellView : Page
    {
        public ShellView(NavigationService navigationService,
                         ShellViewModel shellViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = shellViewModel;
        }
    }
}
