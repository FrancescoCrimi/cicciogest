// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IView : IWin32Window
    {
        event EventHandler? Load;
        event FormClosingEventHandler? FormClosing;

        DialogResult DialogResult { get; set; }

        void Show();
        void Show(IWin32Window owner);
        DialogResult ShowDialog();
        DialogResult ShowDialog(IWin32Window owner);
        void Close();
    }
}
