using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class CategoriaViewModel : ViewModelBase
    {
        private ILogger logger;
        private IKernel kernel;
        private IMagazinoService service;

        /// <summary>
        /// Initializes a new instance of the CategoriaViewModel class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaViewModel(ILogger logger, IKernel kernel, IMagazinoService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            Categorie = new ObservableCollection<Categoria>();
            SalvaCommand = new RelayCommand(salva);
            RimuoviCommand = new RelayCommand(rimuovi);
            NuovoCommand = new RelayCommand(nuova);

            if (IsInDesignMode)
            {
                foreach (Categoria ca in service.GetCategorie())
                {
                    Categorie.Add(ca);
                }
                Categoria = service.GetCategoria(4);
            }
            else
            {
                aggiorna();
            }
        }

        #region Proprietà Pubbliche

        public ObservableCollection<Categoria> Categorie { get; private set; }
        public Categoria Categoria { get; private set; }
        public Categoria CategoriaSelezionata { set { mostra(value); } }
        public ICommand SalvaCommand { get; private set; }
        public ICommand RimuoviCommand { get; private set; }
        public ICommand NuovoCommand { get; private set; }

        #endregion


        #region Metodi Privati

        private void salva()
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
        }

        private void rimuovi()
        {
            try
            {
                service.DeleteCategoria(Categoria.Id);
                aggiorna();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void mostra(Categoria categoria)
        {
            if (categoria != null && categoria != Categoria)
            {
                Categoria = categoria;
                RaisePropertyChanged("Categoria");
            }
        }

        private void nuova()
        {
            mostra(new Categoria());
        }

        private void aggiorna()
        {
            nuova();
            Categorie.Clear();
            foreach (Categoria ca in service.GetCategorie())
            {
                Categorie.Add(ca);
            }
        }

        #endregion
    }
}
