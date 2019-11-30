using System;

namespace CiccioGest.Presentation.Wpf.App1.Service
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        bool CanGoForward { get; }
        Uri CurrentSource { get; }
        void Clear();
        void GoBack();
        void GoForward();
        bool Navigate(object root);
        bool StartNavigate(object root);
    }
}
