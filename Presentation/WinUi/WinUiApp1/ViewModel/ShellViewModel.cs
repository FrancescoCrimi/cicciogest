﻿using CiccioGest.Presentation.WinUiApp1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public sealed class ShellViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService navigationService;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand apriFattureCommand;
        private RelayCommand apriArticoliCommand;
        private RelayCommand apriCategorieCommand;
        private RelayCommand apriClientiCommand;
        private RelayCommand apriFornitoriCommand;
        private RelayCommand<Type> itemInvokedCommand;

        public ShellViewModel(ILogger<ShellViewModel> logger,
                              INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(async () =>
        {
            await Task.CompletedTask;
        });

        public ICommand ApriFattureCommand => apriFattureCommand ??= new RelayCommand(()
            => navigationService.Navigate(Views.Fatture));

        public ICommand ApriArticoliCommand => apriArticoliCommand ??= new RelayCommand(()
            => navigationService.Navigate(Views.Articoli));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??= new RelayCommand(()
            => navigationService.Navigate(Views.Categoria));

        public ICommand ApriClientiCommand => apriClientiCommand ??= new RelayCommand(()
            => navigationService.Navigate(Views.Clienti));

        public ICommand ApriFornitoriCommand => apriFornitoriCommand ??= new RelayCommand(()
            => navigationService.Navigate(Views.Fornitori));

        public ICommand ItemInvokedCommand => itemInvokedCommand ??= new RelayCommand<Type>((type) =>
        {
            if(type != null)
            {
                navigationService.Navigate(type);
            }
        });

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}