using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class ArticoloViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly IMessageBoxService messageBoxService;
        private AsyncRelayCommand loadedCommand;
        private ICommand nuovoCommand;
        private AsyncRelayCommand salvaCommand;
        private AsyncRelayCommand eliminaCommand;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger,
                                 IMagazinoService service,
                                 IMessageBoxService messageBoxService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.messageBoxService = messageBoxService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            Categorie = new ObservableCollection<Categoria>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Articolo Articolo { get; private set; }

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(Nuovo);
        public IAsyncRelayCommand EliminaCommand => eliminaCommand ??= new AsyncRelayCommand(Elimina);
        public IAsyncRelayCommand SalvaCommand => salvaCommand ??= new AsyncRelayCommand(Salva);
        public IAsyncRelayCommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(async () =>
        {
            foreach (Categoria cat in await service.GetCategorie())
            {
                Categorie.Add(cat);
            }
            await Aggiorna();
        });

        public ArticoloReadOnly ArticoloSelezionato
        {
            set
            {
                if (value != null && value.Id != 0)
                {
                    Task.Run(async () =>
                    {
                        Articolo = await service.GetArticolo(value.Id);
                        OnPropertyChanged(nameof(Articolo));
                    });
                }
            }
        }

        private async Task Aggiorna()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Articoli.Add(pr);
            }
            Nuovo();
        }

        private void Nuovo()
        {
            Articolo = new Articolo();
            OnPropertyChanged(nameof(Articolo));
        }

        private async Task Elimina()
        {
            try
            {
                await service.DeleteArticolo(Articolo.Id);
                await Aggiorna();
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        }

        private async Task Salva()
        {
            try
            {
                await service.SaveArticolo(Articolo);
                await Aggiorna();
            }
            catch (Exception e)
            {
                messageBoxService.Show("Errore: " + e.Message);
            }
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }

    }
}
