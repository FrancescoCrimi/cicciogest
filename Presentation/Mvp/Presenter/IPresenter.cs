using System;

namespace CiccioGest.Presentation.Mvp.Presenter
{
    public interface IPresenter : IDisposable
    {
        void Show();
        void ShowDialog(Object owner);
        object View { get; }
    }
}