using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IView
    {
        event EventHandler LoadEvent;
        event EventHandler CloseEvent;
        void Show();
        DialogResult ShowDialog(IWin32Window owner);
        void Close();
    }
}
