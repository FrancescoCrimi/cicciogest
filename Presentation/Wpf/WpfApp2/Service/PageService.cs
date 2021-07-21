//using Castle.Core.Logging;
//using Castle.MicroKernel;
//using Castle.MicroKernel.Lifestyle;
using CiccioGest.Presentation.WpfApp2.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.Service
{
    class PageService : IPageService
    {
        private readonly Dictionary<string, Type> pages = new Dictionary<string, Type>();
        private readonly ILogger logger;
        private readonly IKernel kernel;

        public PageService(ILogger<PageService> logger, IKernel kernel)
        {
            this.logger = logger;
            this.kernel = kernel;
        }

        public void Configure<V>()
            where V : Page
        {
            lock (pages)
            {
                var key = typeof(V).Name.Split(new string[] { "View" }, StringSplitOptions.None).First();
                if (pages.ContainsKey(key))
                {
                    throw new ArgumentException($"The key {key} is already configured in PageService");
                }
                var type = typeof(V);
                if (pages.Any(p => p.Value == type))
                {
                    throw new ArgumentException($"This type is already configured with key {pages.First(p => p.Value == type).Key}");
                }
                pages.Add(key, type);
            }
        }

        public Page GetPage(string key)
        {
            var pageType = GetPageType(key);
            using (kernel.BeginScope())
            {
                return kernel.Resolve(pageType) as Page;
            }
        }

        public Type GetPageType(string key)
        {
            Type pageType;
            lock (pages)
            {
                if (!pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }
            return pageType;
        }
    }
}
