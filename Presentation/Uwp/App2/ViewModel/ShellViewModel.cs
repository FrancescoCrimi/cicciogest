using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Uwp.App2.ViewModel
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly NavigationService navigationService;
        private ICommand itemInvokedCommand;

        public ShellViewModel(ILogger logger, IKernel kernel, NavigationService navigationService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.navigationService = navigationService;
        }

        public void Initialize(Frame frame) => navigationService.CurrentFrame = frame;

        public ICommand ItemInvokedCommand => itemInvokedCommand ??= new RelayCommand<NavigationViewItemInvokedEventArgs>((obj) =>
        {
            if (obj.IsSettingsInvoked == true)
            {
                //NavView_Navigate("settings", obj.RecommendedNavigationTransitionInfo);
            }
            else if (obj.InvokedItemContainer != null)
            {
                var navItemTag = obj.InvokedItemContainer.Tag.ToString();
                using (kernel.BeginScope())
                {
                    navigationService.NavigateTo(navItemTag);
                }
                //if (navItemTag == "FatturaPage") navigationService.NavigateTo("FatturaPage");
                //NavView_Navigate(navItemTag, obj.RecommendedNavigationTransitionInfo);
            }
        });
    }
}
