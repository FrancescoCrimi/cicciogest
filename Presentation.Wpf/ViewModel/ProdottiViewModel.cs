using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CiccioGest.Domain;
using CiccioGest.Application;
using System.Collections.ObjectModel;
using CiccioGest.Presentation.Wpf.Utils;
using Castle.Core.Logging;

namespace CiccioGest.Presentation.Wpf.ViewModel
{
    public class ProdottiViewModel : ObservableObject
    {
        private IProdottoService service;
        private ILogger logger;

        public ProdottiViewModel(IProdottoService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
            Prodotti = new ObservableCollection<Prodotto>();
            Categorie = new ObservableCollection<Categoria>();

            var categorie = this.service.GetCategorie();
            foreach (Categoria cat in categorie)
            {
                Categorie.Add(cat);
            }
            aggiorna();
        }


        #region Metodi Privati

        private void aggiorna()
        {
            Prodotti.Clear();
            var prodotti = service.GetProdotti();
            foreach (Prodotto pr in prodotti)
            {
                Prodotti.Add(pr);
            }
            nuovoProdotto();
        }
        private void nuovoProdotto()
        {
            //Prodotto =   Factory.NuovoProdotto();
            Prodotto = null;
            RaisePropertyChanged("Prodotto");
        }

        #endregion


        #region Proprietà Pubbliche

        public ObservableCollection<Prodotto> Prodotti { get; private set; }
        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Prodotto Prodotto { get; private set; }
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
        public ICommand NuovoCommand { get { return new RelayCommand(() => nuovoProdotto()); } }
        public ICommand EliminaCommand
        {
            get
            {
                return new RelayCommand(() => 
                {
                    try
                    {
                        service.DeleteProdotto(Prodotto);
                        aggiorna();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Errore: " + e.Message);
                    }
                });
            }
        }
        public ICommand SalvaCommand
        {
            get
            {
                return new RelayCommand(() => 
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
                });
            }
        }

        #endregion
    }
}
