using CiccioGest.Presentation.Wpf.App1.Contracts;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.Design
{
    class DesignNavigationService : INavigationService
    {
        public bool CanGoBack => throw new NotImplementedException();
        public bool CanGoForward => throw new NotImplementedException();
        public Uri CurrentSource => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public void GoBack() => throw new NotImplementedException();
        public void GoForward() => throw new NotImplementedException();
        public void Initialize(Frame shellFrame) => throw new NotImplementedException();
        public void NavigateTo(string pageKey, bool clearNavigation = false)
            => throw new NotImplementedException();
    }
}
