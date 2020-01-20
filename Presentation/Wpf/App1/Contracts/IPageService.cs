using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.Contracts
{
    public interface IPageService
    {
        Type GetPageType(string key);
        Page GetPage(string key);
        void Configure<V>() where V : Page;
    }
}
