using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.Contracts
{
    public interface IWindowManagerService
    {
        Window MainWindow { get; }

        void OpenInNewWindow(WindowKey pageKey);

        bool? OpenInDialog(WindowKey pageKey);

        Window GetWindow(WindowKey pageKey);
    }
}
