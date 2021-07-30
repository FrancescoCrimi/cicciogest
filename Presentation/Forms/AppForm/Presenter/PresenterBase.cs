using CiccioGest.Presentation.AppForm.View;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public abstract class PresenterBase
    {
        private readonly IView view;

        protected PresenterBase(IView view)
        {
            this.view = view;
        }

        public object View => view;

        public void Show() => view.Show();

        public DialogResult ShowDialog(IWin32Window owner) => view.ShowDialog(owner);
    }
}
