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
    public class CategorieViewModel : ObservableObject
    {
        private ICiccioService service = null;

        public CategorieViewModel(ICiccioService categoriaProdottoService)
        {
            service = categoriaProdottoService;
            TipiProdotto = new ObservableCollection<Categoria>();
            aggiorna();
        }


        #region Proprietà Pubbliche

        public ObservableCollection<Categoria> TipiProdotto { get; private set; }
        public Categoria TipoProdotto { get; private set; }
        public Categoria TipoProdottoSelezionato { set { selezionaTipoProdotto(value); } }


        public ICommand SalvaCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        service.SaveCategoria(TipoProdotto);
                        aggiorna();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Errore: " + e.Message);
                    }
                });
            }
        }

        public ICommand RimuoviCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        service.DeleteCategoria(TipoProdotto);
                        aggiorna();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Errore: " + e.Message);
                    }
                });
            }
        }

        public ICommand NuovoCommand
        {
            get
            {
                return new RelayCommand(() => nuovo());
            }
        }

        #endregion


        #region Metodi Privati

        private void selezionaTipoProdotto(Categoria tipoProdotto)
        {
            if (tipoProdotto != null && tipoProdotto != this.TipoProdotto)
            {
                this.TipoProdotto = tipoProdotto;
                RaisePropertyChanged("TipoProdotto");
            }
        }

        private void nuovo()
        {
            TipoProdotto = Factory.NewTransientCategoria();
            RaisePropertyChanged("TipoProdotto");
        }

        private void aggiorna()
        {
            nuovo();
            var tipiProdotto = service.GetCategorie();
            TipiProdotto.Clear();
            foreach (Categoria tp in tipiProdotto)
            {
                TipiProdotto.Add(tp);
            }
        }

        #endregion
    }
}
