namespace CiccioGest.Presentation.Wpf.App2.Contracts
{
    public interface IWindowManagerService
    {
        void OpenInNewWindow(WindowKey pageKey);

        bool? OpenInDialog(WindowKey pageKey);
    }
}
