using CiccioGest.Presentation.WpfApp2.Contracts;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.Design
{
    class DesignNavigationService : INavigationService
    {
        public bool CanGoBack => throw new NotImplementedException();

        public void CleanNavigation() => throw new NotImplementedException();

        public void GoBack() => throw new NotImplementedException();

        public void Initialize(Frame shellFrame) => throw new NotImplementedException();

        public void NavigateTo(string pageKey, bool clearNavigation = false)
            => throw new NotImplementedException();
    }
}
