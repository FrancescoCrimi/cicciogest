using System;

namespace CiccioGest.Presentation.WpfApp.Contracts
{
    public interface IWindowDialogService
    {
        bool? OpenDialog(Type windowType, object parameter = null);
    }
}
