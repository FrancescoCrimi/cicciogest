using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.AppWpf.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ProdottoViewModel : ViewModelBase
    {
        private ILogger logger;
        private IKernel kernel;
        private IMagazinoService service;

        /// <summary>
        /// Initializes a new instance of the ProdottoViewModel class.
        /// </summary>
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
        }


        #region Proprietà Pubbliche

        public ObservableCollection<ProdottoReadOnly> Prodotti { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Prodotto Prodotto { get; private set; }
        public ICommand NuovoCommand { get; private set; }
        public ICommand EliminaCommand { get; private set; }
        public ICommand SalvaCommand { get; private set; }
        public Prodotto ProdottoSelezionato
        {
            set
            {
                if (value != null && value != Prodotto)
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
            Messenger.Default.Register<CaricaProdotto>(this, cp =>
            {
                switch (cp.What)
                {
                    case LoadType.Nuova:
                        aggiorna();
                        break;
                    case LoadType.Cerca:
                        var spv = new SelezionaProdottoView();
                        spv.ShowDialog();
                        break;
                    case LoadType.Carica:
                        Prodotto = service.GetProdotto(cp.IdProdotto);
                        RaisePropertyChanged("Prodotto");
                        break;
                    default:
                        break;
                }
            });
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

        #endregion

    }
}