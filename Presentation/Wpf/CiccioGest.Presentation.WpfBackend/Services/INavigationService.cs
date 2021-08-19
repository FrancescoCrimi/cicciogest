using System;

namespace CiccioGest.Presentation.WpfBackend.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        //bool CanGoForward { get; }
        void GoBack();
        //void GoForward();
        //void Initialize(Frame shellFrame);
        void NavigateTo(Type pageType,
                        object parameter = null,
                        bool clearNavigation = false);
        void NavigateTo(string key,
                        object parameter = null,
                        bool clearNavigation = false);
    }
}
