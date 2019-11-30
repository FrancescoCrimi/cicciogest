using Castle.Core.Logging;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.Wpf.App1.Service
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly System.Windows.Navigation.NavigationService ns;
        private readonly Frame frame;

        public NavigationService(ILogger logger, Frame frame)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.frame = frame ?? throw new ArgumentNullException(nameof(frame));
            ns = this.frame.NavigationService;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public bool CanGoBack => ns.CanGoBack;
        public bool CanGoForward => ns.CanGoForward;
        public Uri CurrentSource => ns.CurrentSource;
        public void GoBack() => ns.GoBack();
        public void GoForward() => ns.GoForward();
        public bool Navigate(object root) => ns.Navigate(root);

        public bool StartNavigate(object root)
        {
            bool b = ns.Navigate(root);
            frame.LoadCompleted += Frame_LoadCompleted;
            return b;
        }

        private void Frame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            Clear();
            frame.LoadCompleted -= Frame_LoadCompleted;
        }

        public void Clear()
        {
            while (ns.CanGoBack)
            {
                frame.NavigationService.RemoveBackEntry();
            }
        }
    }
}
