using CiccioGest.Presentation.UwpApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class ShellViewModel : ObservableObject
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private ICommand itemInvokedCommand;

        public ShellViewModel(ILogger<ShellViewModel> logger, NavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
        }

        public void Initialize(Frame frame)
        {
            navigationService.Initialize(frame);
        }

        public ICommand ItemInvokedCommand => itemInvokedCommand ?? (itemInvokedCommand = new RelayCommand<NavigationViewItemInvokedEventArgs>((obj) =>
        {
            if (obj.IsSettingsInvoked == true)
            {
                //NavView_Navigate("settings", obj.RecommendedNavigationTransitionInfo);
            }
            else if (obj.InvokedItemContainer != null)
            {
                var navItemTag = obj.InvokedItemContainer.Tag.ToString();
                //using (kernel.BeginScope())
                //{
                //    navigationService.NavigateTo(navItemTag);
                //}
                ////if (navItemTag == "FatturaPage") navigationService.NavigateTo("FatturaPage");
                ////NavView_Navigate(navItemTag, obj.RecommendedNavigationTransitionInfo);
            }
        }));
    }
}
