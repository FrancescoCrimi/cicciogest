using CiccioGest.Presentation.Mvp.View;

namespace CiccioGest.Presentation.Mvp.Presenter
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

        public void ShowDialog(object owner) => view.ShowDialog(owner);
    }
}
