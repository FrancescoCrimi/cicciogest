using System;

namespace CiccioGest.Presentation.WpfApp.Contracts
{
    public interface IWindowManagerService
    {
        void OpenWindow(Type windowType, object parameter = null);
    }
}
