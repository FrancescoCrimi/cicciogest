// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.AppForm.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenters
{
    public abstract class PresenterBase : IDisposable
    {
        private IView _view;

        protected PresenterBase(IView view) => _view = view;

        public void Show() => _view.Show();
        public void Show(IWin32Window owner) => _view.Show(owner);
        public DialogResult ShowDialog() => _view.ShowDialog();
        public DialogResult ShowDialog(IWin32Window owner) => _view.ShowDialog(owner);

        public virtual void Dispose() => _view = null!;
    }

    // Presenter che può ricevere un parametro
    public interface IInitializable
    {
        //void Initialize(object? parameter);
        //Task InitializeAsync(object? parameter) => Task.Run(() => Initialize(parameter));
        Task InitializeAsync(object? parameter);
    }

    // Presenter che fornisce un risultato tipizzato
    public interface IResultProvider<out TResult>
    {
        TResult GetResult();
    }
}
