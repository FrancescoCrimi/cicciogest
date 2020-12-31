using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Presentation.WpfApp2.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.WpfApp2.Service
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IPageService pageService;
        private Frame frame;
        private bool clearNavigation;
        private readonly HashSet<Page> listPages = new HashSet<Page>();

        public NavigationService(ILogger logger, IKernel kernel, IPageService pageService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.pageService = pageService;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void Initialize(Frame shellFrame)
        {
            if (frame == null)
            {
                frame = shellFrame;
                frame.Navigated += OnNavigated;
            }
        }

        public bool CanGoBack => frame.CanGoBack;
        public void GoBack() => frame.GoBack();

        public void NavigateTo(string pageKey, bool clearNavigation = false)
        {
            var pageType = pageService.GetPageType(pageKey);
            if (frame.Content?.GetType() != pageType)
            {
                var page = pageService.GetPage(pageKey);
                frame.Navigate(page);
                this.clearNavigation = clearNavigation;
            }
        }

        public void CleanNavigation()
        {
            while (frame.CanGoBack)
            {
                frame.RemoveBackEntry();
            }
            foreach (var item in listPages)
            {
                Debug.WriteLine("Item Deleted: " + item.GetHashCode().ToString());
                kernel.ReleaseComponent(item);
            }
            listPages.Clear();
            clearNavigation = false;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                if (clearNavigation)
                {
                    CleanNavigation();
                }
                if (frame.Content != null)
                {
                    var currentPage = (Page)frame.Content;
                    listPages.Add(currentPage);
                }
            }
        }
    }
}
