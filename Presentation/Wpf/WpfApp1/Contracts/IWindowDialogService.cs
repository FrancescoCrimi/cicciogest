using System;

namespace CiccioGest.Presentation.WpfApp1.Contracts
{
    public interface IWindowDialogService
    {
        bool? OpenDialog(Type windowType, object parameter = null);
    }
}
