using CiccioGest.Presentation.Wpf.App1.Contracts;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.Design
{
    class DesignPageService : IPageService
    {
        public void Configure<V>() where V : Page { }

        public Page GetPage(string key)
        {
            throw new NotImplementedException();
        }

        public Type GetPageType(string key)
        {
            throw new NotImplementedException();
        }
    }
}
