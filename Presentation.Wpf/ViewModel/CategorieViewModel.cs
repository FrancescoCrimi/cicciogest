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
using Castle.Core.Logging;

namespace Ciccio1.Presentation.Wpf.ViewModel
{
    public class CategorieViewModel : ObservableObject
    {
        private ICategoriaService service;
        private ILogger logger;

        public CategorieViewModel(ICategoriaService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
            Categorie = new ObservableCollection<Categoria>();
            aggiorna();
        }


        #region Proprietà Pubbliche

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { settaCategoria(value); } }
        public ICommand SalvaCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        service.SaveCategoria(Categoria);
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
                        service.DeleteCategoria(Categoria);
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

        private void settaCategoria(Categoria categoria)
        {
            if (categoria != null && categoria != Categoria)
            {
                Categoria = categoria;
                RaisePropertyChanged("Categoria");
            }
        }

        private void nuovo()
        {
            Categoria = Factory.NewCategoria();
            RaisePropertyChanged("Categoria");
        }

        private void aggiorna()
        {
            nuovo();
            var lp = service.GetCategorie();
            Categorie.Clear();
            foreach (Categoria ca in lp)
            {
                Categorie.Add(ca);
            }
        }

        #endregion
    }
}
