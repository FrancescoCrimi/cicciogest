using Castle.Core.Logging;
using GalaSoft.MvvmLight;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public class HomeViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        public HomeViewModel(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void Dispose()
        {
            //UnRegister();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
