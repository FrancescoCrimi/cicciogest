using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.Service
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IPageService pageService;
        private Frame frame;
        private bool clearNavigation;
        private readonly List<Page> listPages = new List<Page>();

        public NavigationService(ILogger logger, IKernel kernel, IPageService pageService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.pageService = pageService;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public bool CanGoBack => frame.CanGoBack;
        public bool CanGoForward => frame.CanGoForward;
        public Uri CurrentSource => frame.CurrentSource;
        public void GoBack() => frame.GoBack();
        public void GoForward() => frame.GoForward();

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

        public void Clear()
        {
            while (frame.CanGoBack)
            {
                frame.NavigationService.RemoveBackEntry();
            }
            foreach (var item in listPages)
            {
                kernel.ReleaseComponent(item);
            }
            listPages.Clear();
            clearNavigation = false;
        }

        public void Initialize(Frame shellFrame)
        {
            if (frame == null)
            {
                frame = shellFrame;
                frame.Navigated += Frame_Navigated;
            }
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (clearNavigation)
                Clear();
            var currentPage = (Page)frame.Content;
            listPages.Add(currentPage);
        }
    }
}
