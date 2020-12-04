using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ArticoloViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand salvaCommand;
        private ICommand eliminaCommand;

        public ArticoloViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            Categorie = new ObservableCollection<Categoria>();

            if (IsInDesignMode)
            {
                Articolo = service.GetArticolo(4).Result;
                foreach (Categoria cat in service.GetCategorie().Result)
                {
                    Categorie.Add(cat);
                }
                foreach (ArticoloReadOnly pr in service.GetArticoli().Result)
                {
                    Articoli.Add(pr);
                }
            }

            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
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
                        RaisePropertyChanged(nameof(Articolo));
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
            RaisePropertyChanged(nameof(Articolo));
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
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }

    }
}
