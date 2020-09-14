using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App2.ViewModel
{
    public sealed class ArticoloViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand salvaCommand;
        private ICommand eliminaCommand;
        private ArticoloReadOnly articoloSelezionato;

        public ArticoloViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            Categorie = new ObservableCollection<Categoria>();

            if (App.InDesignMode)
            {
                Prodotto = service.GetArticolo(4).Result;
                foreach (Categoria cat in service.GetCategorie().Result)
                {
                    Categorie.Add(cat);
                }
                foreach (ArticoloReadOnly pr in service.GetArticoli().Result)
                {
                    Prodotti.Add(pr);
                }
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovoCommand => nuovoCommand ??= new RelayCommand(Nuovo);

        public ICommand EliminaCommand => eliminaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await service.DeleteArticolo(Prodotto.Id);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand SalvaCommand => salvaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await service.SaveArticolo(Prodotto);
                await Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (Categoria cat in await service.GetCategorie())
            {
                Categorie.Add(cat);
            }
            await Aggiorna();
        });

        public Articolo Prodotto { get; private set; }

        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }

        public ObservableCollection<Categoria> Categorie { get; private set; }

        public ArticoloReadOnly ProdottoSelezionato
        {
            set
            {
                if (value != articoloSelezionato)
                {
                    Task.Run(async () =>
                    {
                        articoloSelezionato = value;
                        Prodotto = await service.GetArticolo(value.Id);
                        RaisePropertyChanged(nameof(Prodotto));
                    });
                }
            }
        }

        private async Task Aggiorna()
        {
            Prodotti.Clear();
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Prodotti.Add(pr);
            }
            Nuovo();
        }

        private void Nuovo()
        {
            Prodotto = new Articolo();
            RaisePropertyChanged(nameof(Prodotto));
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
