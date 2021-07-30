using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public interface IPresenter : IDisposable
    {
        void Show();
        DialogResult ShowDialog(IWin32Window owner);
        object View { get; }
    }
}