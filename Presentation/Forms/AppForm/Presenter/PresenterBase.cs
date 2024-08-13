// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.AppForm.View;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public abstract class PresenterBase
    {
        private readonly IView _view;

        protected PresenterBase(IView view)
        {
            _view = view;
        }

        public object View => _view;

        public void Show() => _view.Show();

        public DialogResult ShowDialog(IWin32Window owner) => _view.ShowDialog(owner);
    }
}
