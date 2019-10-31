using System;

namespace CiccioGest.Presentation.AppWpf
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
