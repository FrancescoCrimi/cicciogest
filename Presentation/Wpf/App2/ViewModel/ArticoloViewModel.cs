using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
//using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App2.ViewModel
{
    public sealed class ArticoloViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand loadedCommand;
        private ICommand nuovoCommand;
        private ICommand salvaCommand;
        private ICommand eliminaCommand;
        private ArticoloReadOnly prodottoSelezionato;

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
            else
            {
                RegistraMessaggi();
            }
            //Aggiorna();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovoCommand => nuovoCommand ?? (nuovoCommand = new RelayCommand(Nuovo));
        public ICommand EliminaCommand => eliminaCommand ?? (eliminaCommand = new RelayCommand(async () => await Elimina()));
        public ICommand SalvaCommand => salvaCommand ?? (salvaCommand = new RelayCommand(async () => await Salva()));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            foreach (Categoria cat in await service.GetCategorie())
            {
                Categorie.Add(cat);
            }
            await Aggiorna();
        }));

        public Articolo Prodotto { get; private set; }
        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato
        {
            set
            {
                if (value != prodottoSelezionato)
                {
                    Task.Run(async () =>
                    {
                        prodottoSelezionato = value;
                        Prodotto = await service.GetArticolo(value.Id);
                        RaisePropertyChanged(nameof(Prodotto));
                    });
                }
            }
        }


        #region Metodi Privati

        private void RegistraMessaggi()
        {
            //MessengerInstance.Register<CaricaProdotto>(this, cp =>
            //{
            //    switch (cp.What)
            //    {

            //        case LoadType.Nuova:
            //            aggiorna();
            //            break;

            //        case LoadType.Cerca:
            //            var spv = new SelezionaProdottoView();
            //            spv.ShowDialog();
            //            break;

            //        case LoadType.Carica:
            //            Prodotto = service.GetProdotto(cp.IdProdotto);
            //            RaisePropertyChanged("Prodotto");
            //            break;
            //        default:
            //            break;
            //    }
            //});
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
            //Prodotto = null;
            RaisePropertyChanged(nameof(Prodotto));
        }

        private async Task Elimina()
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
        }

        private async Task Salva()
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
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }

        #endregion

    }
}
