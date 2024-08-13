// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using System.Windows;

namespace CiccioGest.Presentation.WpfBackend.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void Show(string messageBoxText)
        {
            MessageBox.Show(messageBoxText);
        }
    }
}
