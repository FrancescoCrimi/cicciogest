using System;
using CiccioGest.Presentation.Wpf.App1.Service;

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
        public bool Navigate(object root) => throw new NotImplementedException();
        public bool StartNavigate(object root) => throw new NotImplementedException();
    }
}
