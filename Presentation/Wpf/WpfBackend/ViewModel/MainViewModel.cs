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

        public MainViewModel(ILogger<MainViewModel> logger,
                             INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand ??=
            new RelayCommand(() => navigationService.NavigateTo(nameof(FattureViewModel), true));

        public ICommand ApriArticoliCommand => apriArticoliCommand ??=
            new RelayCommand(() => navigationService.NavigateTo(nameof(ArticoliViewModel), true));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??=
            new RelayCommand(() => navigationService.NavigateTo(nameof(CategoriaViewModel), true));

        public ICommand ApriClientiCommand => apriClientiCommand ??=
            new RelayCommand(() => navigationService.NavigateTo(nameof(ClientiViewModel)));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }

        private RelayCommand<Type> menuItemCommand;
        public ICommand MenuItemCommand
        {
            get
            {
                return menuItemCommand ??= new RelayCommand<Type>(MenuItem);
            }
        }

        private void MenuItem(Type type)
        {
            navigationService.NavigateTo(type);
        }
    }
}
