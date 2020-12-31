using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.Contracts
{
    public interface INavigationService
    {
        bool CanGoBack { get; }

        void Initialize(Frame shellFrame);
        //bool CanGoForward { get; }
        //Uri CurrentSource { get; }
        void CleanNavigation();
        void GoBack();
        //void GoForward();
        void NavigateTo(string pageKey, bool clearNavigation = false);
    }
}
