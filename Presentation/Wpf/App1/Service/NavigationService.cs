using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.Wpf.App1.Service
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private Frame frame;
        private System.Windows.Navigation.NavigationService ns;

        public NavigationService(ILogger logger, IKernel kernel)
        {
            this.logger = logger;
            this.kernel = kernel;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public bool CanGoBack => ns.CanGoBack;
        public bool CanGoForward => ns.CanGoForward;
        public Uri CurrentSource => ns.CurrentSource;
        public void GoBack() => ns.GoBack();
        public void GoForward() => ns.GoForward();




        public void NavigateTo(string pageKey)
            => NavigateTo(pageKey, false);


        public void NavigateTo(string pageKey, bool clearNavigation)
        {
            var pageType = GetPageType(pageKey);
            if (frame.Content?.GetType() != pageType)
            {
                frame.Tag = clearNavigation;
                var page = GetPage(pageKey);
                var navigated = frame.Navigate(page);
                if (navigated & clearNavigation)
                {
                    frame.LoadCompleted += Frame_LoadCompleted;
                }
            }
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



        public Type GetPageType(string key)
        {
            Type pageType;
            lock (_pages)
            {
                if (!_pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return pageType;
        }

        public Page GetPage(string key)
        {
            var pageType = GetPageType(key);
            return kernel.Resolve(pageType) as Page;
        }

        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        public void Configure<V>()
            where V : Page
        {
            lock (_pages)
            {
                //var key = typeof(VM).FullName;
                var key = typeof(V).Name.Split(new string[] { "View" }, StringSplitOptions.None).First();
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }
                var type = typeof(V);
                if (_pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
                }
                _pages.Add(key, type);
            }
        }

        public void Initialize(Frame shellFrame)
        {
            if (frame == null)
            {
                frame = shellFrame;
                ns = shellFrame.NavigationService;
            }
        }
    }
}
