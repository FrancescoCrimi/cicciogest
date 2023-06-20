using System;

namespace CiccioGest.Presentation.WinUiApp1.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        bool CanGoForward { get; }

        void GoBack();
        void GoForward();
        bool Navigate(Type pageType, object parameter = null, bool clearNavigation = false);
        bool Navigate(Views key, object parameter = null, bool clearNavigation = false);
        //bool Navigate<T>(object parameter = null, bool clearNavigation = false) where T : Page;
    }
}