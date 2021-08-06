using CiccioGest.Presentation.UwpApp.Helpers;
using CiccioGest.Presentation.UwpApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private ICommand itemInvokedCommand;

        public MainViewModel(ILogger<MainViewModel> logger, NavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
        }

        public void Initialize(Frame frame)
        {
            navigationService.Initialize(frame);
        }

        public ICommand ItemInvokedCommand => itemInvokedCommand ?? (itemInvokedCommand = new RelayCommand<WinUI.NavigationViewItemInvokedEventArgs>(obj =>
        {
            if (obj.IsSettingsInvoked == true)
            {
                //NavView_Navigate("settings", obj.RecommendedNavigationTransitionInfo);
            }
            else if (obj.InvokedItemContainer != null)
            {
                var selectedItem = obj.InvokedItemContainer as WinUI.NavigationViewItem;
                var pageType = selectedItem?.GetValue(NavHelper.NavigateToProperty) as Type;
                navigationService.Navigate(pageType);

                //var navItemTag = obj.InvokedItemContainer.Tag.ToString();
                ////if (navItemTag == "FatturaPage") navigationService.NavigateTo("FatturaPage");
                ////NavView_Navigate(navItemTag, obj.RecommendedNavigationTransitionInfo);
            }
        }));
    }
}
