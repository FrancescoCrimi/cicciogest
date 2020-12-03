using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Presentation.Wpf.App2
{
    public interface IWindowManagerService
    {
        void OpenInNewWindow(WindowKey pageKey);

        bool? OpenInDialog(WindowKey pageKey);
    }
}
