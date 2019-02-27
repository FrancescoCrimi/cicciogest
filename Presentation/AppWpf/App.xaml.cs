using System.Windows;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Threading;

namespace CiccioGest.Presentation.AppWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }    
    }
}
