using CiccioGest.Presentation.WpfApp1.Contracts;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.Design
{
    class DesignWindowManagerService : IWindowManagerService
    {
        public Window MainWindow => throw new NotImplementedException();

        public Window GetWindow(WindowKey pageKey)
        {
            throw new NotImplementedException();
        }

        public bool? OpenInDialog(WindowKey pageKey)
        {
            throw new NotImplementedException();
        }

        public void OpenInNewWindow(WindowKey pageKey)
        {
            throw new NotImplementedException();
        }
    }
}
