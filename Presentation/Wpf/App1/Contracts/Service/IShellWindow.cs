using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.Contracts.Service
{
    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();
    }
}
