using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.Contracts
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        //bool CanGoForward { get; }
        void GoBack();
        //void GoForward();
        void Initialize(Frame shellFrame);
        void NavigateTo(Type pageType, bool clearNavigation = false);
    }
}
