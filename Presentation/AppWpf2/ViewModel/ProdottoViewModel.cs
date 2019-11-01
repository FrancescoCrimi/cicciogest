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
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf2.ViewModel
{
    public sealed class ProdottoViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;

        public ProdottoViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            Categorie = new ObservableCollection<Categoria>();

            if (IsInDesignMode)
            {
                Prodotto = service.GetArticolo(4);
                foreach (Categoria cat in service.GetCategorie())
                {
                    Categorie.Add(cat);
                }
                foreach (ArticoloReadOnly pr in service.GetArticoli())
                {
                    Prodotti.Add(pr);
                }
            }
            else
            {
                NuovoCommand = new RelayCommand(Nuovo);
                SalvaCommand = new RelayCommand(Salva);
                EliminaCommand = new RelayCommand(Elimina);
                RegistraMessaggi();
                foreach (Categoria cat in service.GetCategorie())
                {
                    Categorie.Add(cat);
                }
            }
            Aggiorna();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }


        #region Proprietà Pubbliche

        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Articolo Prodotto { get; private set; }
        public ICommand NuovoCommand { get; private set; }
        public ICommand EliminaCommand { get; private set; }
        public ICommand SalvaCommand { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato
        {
            set
            {
                if (value != null)
                {
                    Prodotto = service.GetArticolo(value.Id);
                    RaisePropertyChanged(nameof(Prodotto));
                }
            }
        }

        #endregion


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

        private void Aggiorna()
        {
            Prodotti.Clear();
            foreach (ArticoloReadOnly pr in service.GetArticoli())
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

        private void Elimina()
        {
            try
            {
                service.DeleteArticolo(Prodotto.Id);
                Aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void Salva()
        {
            try
            {
                service.SaveArticolo(Prodotto);
                Aggiorna();
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
