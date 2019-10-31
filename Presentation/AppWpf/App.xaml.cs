using Castle.Facilities.Logging;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using GalaSoft.MvvmLight.Threading;

namespace CiccioGest.Presentation.AppWpf
{
    public partial class App : System.Windows.Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        public static bool InDesignMode()
        {
            //if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            return !(System.Windows.Application.Current is App);
        }
        private static IWindsorContainer windsor;

        public static IWindsorContainer Windsor => windsor ?? (CreateContainer());

        private static IWindsorContainer CreateContainer()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            return windsor;
        }
    }
}
