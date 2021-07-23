using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class ArticoloViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand salvaCommand;
        private ICommand eliminaCommand;

        public ArticoloViewModel(ILogger<ArticoloViewModel> logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            Categorie = new ObservableCollection<Categoria>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Articolo Articolo { get; private set; }

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(Nuovo);
        public ICommand EliminaCommand => eliminaCommand ??= new RelayCommand(Elimina);
        public ICommand SalvaCommand => salvaCommand ??= new RelayCommand(Salva);
        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
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

        private async void Elimina()
        {
            try
            {
                await service.DeleteArticolo(Articolo.Id);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private async void Salva()
        {
            try
            {
                await service.SaveArticolo(Articolo);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }

    }
}
