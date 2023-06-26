// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;

namespace CiccioGest.Presentation.WinUiNav.ViewModel
{
    public class DashboardViewModel : ObservableObject
    {

        private string text;

        public DashboardViewModel()
        {
            text = "Dashboard";
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
    }
}
