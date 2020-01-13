using System;
using System.Windows.Controls;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.Service;

namespace CiccioGest.Presentation.Wpf.App1.Design
{
    class DesignNavigationService : INavigationService
    {
        public bool CanGoBack => throw new NotImplementedException();
        public bool CanGoForward => throw new NotImplementedException();
        public Uri CurrentSource => throw new NotImplementedException();
        public void Clear() => throw new NotImplementedException();
        public void Configure<V>() where V : Page { }
        public void GoBack() => throw new NotImplementedException();
        public void GoForward() => throw new NotImplementedException();
        public void Initialize(Frame shellFrame) => throw new NotImplementedException();

        public void NavigateTo(string pageKey, bool clearNavigation)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }
        //public bool Navigate(object root) => throw new NotImplementedException();
        //public bool StartNavigate(object root) => throw new NotImplementedException();
    }
}
