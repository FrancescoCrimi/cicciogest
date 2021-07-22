using System;

namespace CiccioGest.Presentation.WpfApp1.Contracts
{
    public interface IWindowManagerService
    {
        void OpenWindow(Type windowType, object parameter = null);
    }
}
