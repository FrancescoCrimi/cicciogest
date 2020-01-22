using Castle.Core.Logging;
using GalaSoft.MvvmLight;

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly ILogger logger;

        public MainViewModel(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
