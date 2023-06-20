using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpApp.View;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace CiccioGest.Presentation.UwpApp.Activation
{
    internal class DefaultActivationHandler : ActivationHandler<IActivatedEventArgs>
    {
        private readonly NavigationService _navigationService;

        public DefaultActivationHandler(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override async Task HandleInternalAsync(IActivatedEventArgs args)
        {
            // When the navigation stack isn't restored, navigate to the first page and configure
            // the new page by passing required information in the navigation parameter
            object arguments = null;
            if (args is LaunchActivatedEventArgs launchArgs)
            {
                arguments = launchArgs.Arguments;
            }

            _navigationService.Navigate(typeof(DashboardView), arguments);
            await Task.CompletedTask;
        }

        protected override bool CanHandleInternal(IActivatedEventArgs args)
        {
            // None of the ActivationHandlers has handled the app activation
            return _navigationService.FrameContentIsNull;
        }
    }
}
