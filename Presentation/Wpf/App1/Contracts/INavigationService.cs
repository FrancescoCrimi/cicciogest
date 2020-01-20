using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.Contracts
{
    public interface INavigationService
    {
        bool CanGoBack { get; }
        bool CanGoForward { get; }
        Uri CurrentSource { get; }
        void Clear();
        void GoBack();
        void GoForward();
        void NavigateTo(string pageKey, bool clearNavigation = false);
        void Initialize(Frame shellFrame);
    }
}
