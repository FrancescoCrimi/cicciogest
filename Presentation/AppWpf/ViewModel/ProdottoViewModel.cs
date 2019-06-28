using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppWpf.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
//using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class ProdottoViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IMagazinoService service;

        public ProdottoViewModel(ILogger logger, IKernel kernel, IMagazinoService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            Prodotti = new ObservableCollection<ProdottoReadOnly>();
            Categorie = new ObservableCollection<Categoria>();

            if (IsInDesignMode)
            {
                Prodotto = service.GetProdotto(4);
                foreach (Categoria cat in service.GetCategorie())
                {
                    Categorie.Add(cat);
                }
                foreach (ProdottoReadOnly pr in service.GetProdotti())
                {
                    Prodotti.Add(pr);
                }
            }
            else
            {
                NuovoCommand = new RelayCommand(nuovo);
                SalvaCommand = new RelayCommand(salva);
                EliminaCommand = new RelayCommand(elimina);
                registraMessaggi();
                foreach (Categoria cat in service.GetCategorie())
                {
                    Categorie.Add(cat);
                }
            }
            aggiorna();
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Created");
        }


        #region Proprietà Pubbliche

        public ObservableCollection<ProdottoReadOnly> Prodotti { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Prodotto Prodotto { get; private set; }
        public ICommand NuovoCommand { get; private set; }
        public ICommand EliminaCommand { get; private set; }
        public ICommand SalvaCommand { get; private set; }
        public ProdottoReadOnly ProdottoSelezionato
        {
            set
            {
                if (value != null)
                {
                    Prodotto = service.GetProdotto(value.Id);
                    RaisePropertyChanged("Prodotto");
                }
            }
        }

        #endregion


        #region Metodi Privati

        private void registraMessaggi()
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

        private void aggiorna()
        {
            Prodotti.Clear();
            foreach (ProdottoReadOnly pr in service.GetProdotti())
            {
                Prodotti.Add(pr);
            }
            nuovo();
        }

        private void nuovo()
        {
            Prodotto = new Prodotto();
            //Prodotto = null;
            RaisePropertyChanged("Prodotto");
        }

        private void elimina()
        {
            try
            {
                service.DeleteProdotto(Prodotto.Id);
                aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void salva()
        {
            try
            {
                service.SaveProdotto(Prodotto);
                aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Disposed");
        }

        #endregion

    }
}