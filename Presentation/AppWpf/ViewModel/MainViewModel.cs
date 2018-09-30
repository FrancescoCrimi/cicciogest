using GalaSoft.MvvmLight;
using CiccioGest.Presentation.AppWpf.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using CiccioGest.Presentation.AppWpf.View;
using System;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using Castle.Core.Logging;
using GalaSoft.MvvmLight.Messaging;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILogger logger, IKernel kernel, IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            ApriFattureCommand = new RelayCommand(() =>
            {
                IDisposable disp = kernel.BeginScope();
                var fv = new FatturaView();
                Messenger.Default.Send(new CaricaFattura() { What = LoadType.Cerca });
                fv.ShowDialog();
                kernel.ReleaseComponent(fv);
                disp.Dispose();
            });
            NuovaFatturaCommand = new RelayCommand(() =>
            {
                IDisposable disp = kernel.BeginScope();
                var fv = new FatturaView();
                Messenger.Default.Send(new CaricaFattura() { What = LoadType.Nuova });
                fv.ShowDialog();
                kernel.ReleaseComponent(fv);
                disp.Dispose();
            });
            ApriProdottiCommand = new RelayCommand(() =>
            {
                IDisposable disp = kernel.BeginScope();
                var pv = new ProdottoView();
                Messenger.Default.Send(new CaricaProdotto() { What = LoadType.Cerca });
                pv.ShowDialog();
                kernel.ReleaseComponent(pv);
                disp.Dispose();
            });
            NuovoProdottoCommand = new RelayCommand(() =>
            {
                IDisposable disp = kernel.BeginScope();
                var pv = new ProdottoView();
                Messenger.Default.Send(new CaricaProdotto() { What = LoadType.Nuova });
                pv.ShowDialog();
                kernel.ReleaseComponent(pv);
                disp.Dispose();
            });
            ApriCategorieCommand = new RelayCommand(() =>
            {
                IDisposable disp = kernel.BeginScope();
                var pv = new CategoriaView();
                pv.ShowDialog();
                kernel.ReleaseComponent(pv);
                disp.Dispose();
            });
        }


        public ICommand ApriFattureCommand { get; private set; }
        public ICommand NuovaFatturaCommand { get; private set; }
        public ICommand ApriProdottiCommand { get; private set; }
        public ICommand NuovoProdottoCommand { get; private set; }
        public ICommand ApriCategorieCommand { get; private set; }


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}