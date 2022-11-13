using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class CategoriaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand salvaCommand;
        private AsyncRelayCommand rimuoviCommand;
        private RelayCommand nuovoCommand;
        private RelayCommand selezionaCategoriaCommand;
        private RelayCommand modificaCategoriaCommand;
        private RelayCommand annullaModificheCategoriaCommand;

        public CategoriaViewModel(ILogger<CategoriaViewModel> logger,
                                  IMagazinoService service,
                                  INavigationService navigationService,
                                  IMessageBoxService messageBoxService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            Categorie = new ObservableCollection<Categoria>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        //public Categoria CategoriaSelezionata { set { Mostra(value); } }
        public Categoria CategoriaSelezionata { get; set; }

        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(Aggiorna);
        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(Nuova);
        public IAsyncRelayCommand SalvaCommand => salvaCommand ??= new AsyncRelayCommand(Salva);

        public IAsyncRelayCommand RimuoviCommand => rimuoviCommand ??= new AsyncRelayCommand(Rimuovi);

        public ICommand SelezionaCategoriaCommand => selezionaCategoriaCommand ??= new RelayCommand(() =>
        {
            if (CategoriaSelezionata != null && Categoria != CategoriaSelezionata)
            {
                if (navigationService.CanGoBack)
                {
                    Messenger.Send(new CategoriaIdMessage(CategoriaSelezionata.Id));
                    navigationService.GoBack();
                }
            }
        });

        public ICommand ModificaCategoriaCommand => modificaCategoriaCommand ??= new RelayCommand(() =>
        {
            if (CategoriaSelezionata != null && Categoria != CategoriaSelezionata)
            {
                Categoria = CategoriaSelezionata;
                OnPropertyChanged(nameof(Categoria));
            }
        });

        public ICommand AnnullaModificheCategoriaCommand => annullaModificheCategoriaCommand ??= new RelayCommand(() =>
        {
            Nuova();
        });

        private async Task Salva()
        {
            try
            {
                await service.SaveCategoria(Categoria);
                await Aggiorna();
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        }

        private async Task Rimuovi()
        {
            try
            {
                await service.DeleteCategoria(Categoria.Id);
                await Aggiorna();
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        }

        private void Mostra(Categoria categoria)
        {
            if (categoria != null && categoria != Categoria)
            {
                Categoria = categoria;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        private void Nuova()
        {
            Mostra(new Categoria());
        }

        private async Task Aggiorna()
        {
            Nuova();
            Categorie.Clear();
            foreach (Categoria ca in await service.GetCategorie())
            {
                Categorie.Add(ca);
            }
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
