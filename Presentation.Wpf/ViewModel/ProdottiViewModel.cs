using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Ciccio1.Domain;
using Ciccio1.Application;
using System.Collections.ObjectModel;
using Ciccio1.Presentation.Wpf.Utils;

namespace Ciccio1.Presentation.Wpf.ViewModel
{
    public class ProdottiViewModel : ObservableObject
    {
        private ICiccioService prodottoService = null;

        public ProdottiViewModel(ICiccioService prodottoService)
        {
            this.prodottoService = prodottoService;
            Prodotti = new ObservableCollection<Prodotto>();
            Categorie = new ObservableCollection<Categoria>();

            var categorie = this.prodottoService.GetCategorie();
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
            var prodotti = prodottoService.GetProdotti();
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
                    Prodotto = prodottoService.GetProdotto(value.Id);
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
                        prodottoService.DeleteProdotto(Prodotto);
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
                        prodottoService.SaveProdotto(Prodotto);
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
