// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;

namespace CiccioGest.Presentation.WinUiNav.ViewModel
{
    public class ShellViewModel : ObservableObject
    {

        private string text;

        public ShellViewModel()
        {
            text = "Shell Page";
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
    }
}
