// Copyright (c) 2016 - 2026 Francesco Crimi
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
    // Presenter che può ricevere un parametro
    public interface IInitializable
    {
        Task InitializeAsync(object? parameter);
    }


    public interface IDialogResultProvider<TResult>
    {
        event EventHandler<TResult>? ValueSelected;
    }


    public abstract class PresenterBase : IDisposable
    {
        private IView _view;
        private bool disposedValue;

        protected PresenterBase(IView view) => _view = view;

        public void Show() => _view.Show();
        public void Show(IWin32Window owner) => _view.Show(owner);
        public DialogResult ShowDialog() => _view.ShowDialog();
        public DialogResult ShowDialog(IWin32Window owner) => _view.ShowDialog(owner);
        public void Close() => _view.Close();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminare lo stato gestito (oggetti gestiti)
                    _view.Dispose();
                }

                // TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del finalizzatore
                // TODO: impostare campi di grandi dimensioni su Null
                _view = null!;
                disposedValue = true;
            }
        }

        // // TODO: eseguire l'override del finalizzatore solo se 'Dispose(bool disposing)' contiene codice per liberare risorse non gestite
        // ~PresenterBase()
        // {
        //     // Non modificare questo codice. Inserire il codice di pulizia nel metodo 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Non modificare questo codice. Inserire il codice di pulizia nel metodo 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public abstract class DialogPresenterBase : PresenterBase, IDialogResultProvider<int>
    {
        protected DialogPresenterBase(IView view) : base(view)
        {
        }

        public event EventHandler<int>? ValueSelected;


        protected void NotifySelection(int value)
        {
            ValueSelected?.Invoke(this, value);
            //_view.DialogResult = DialogResult.OK;
        }
    }
}
