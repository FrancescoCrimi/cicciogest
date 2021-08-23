using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class MainViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService navigationService;
        private RelayCommand apriClientiCommand;
        private RelayCommand apriCategorieCommand;
        private RelayCommand apriArticoliCommand;
        private RelayCommand apriFattureCommand;
        private RelayCommand<Type> menuItemCommand;

        public MainViewModel(ILogger<MainViewModel> logger,
                             INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand
            ??= new RelayCommand(()
                => navigationService.NavigateTo(nameof(FattureViewModel)));

        public ICommand ApriArticoliCommand => apriArticoliCommand
            ??= new RelayCommand(()
                => navigationService.NavigateTo(nameof(ArticoliViewModel)));

        public ICommand ApriCategorieCommand => apriCategorieCommand
            ??= new RelayCommand(()
                => navigationService.NavigateTo(nameof(CategoriaViewModel)));

        public ICommand ApriClientiCommand => apriClientiCommand
            ??= new RelayCommand(()
                => navigationService.NavigateTo(nameof(ClientiViewModel)));

        public ICommand MenuItemCommand => menuItemCommand
            ??= new RelayCommand<Type>((type)
                => navigationService.NavigateTo(type));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
