﻿using CiccioGest.Presentation.WinUiApp1.Services;
using CiccioGest.Presentation.WinUiApp1.View;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiApp1.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly NavigationService _navigationService;

    public DefaultActivationHandler(NavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.FrameContentIsNull;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _navigationService.Navigate(typeof(DashboardView), args.Arguments);

        await Task.CompletedTask;
    }
}