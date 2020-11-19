using System;

namespace CiccioGest.Presentation.Mvp.View
{
    public interface IView
    {
        event EventHandler LoadEvent;
        event EventHandler CloseEvent;
        void Show();
    }
}
