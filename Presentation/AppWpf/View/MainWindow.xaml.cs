using System;
using System.Windows;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppWpf.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CiccioGest.Presentation.AppWpf.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            registraMessaggi();
            Closing += MainWindow_Closing;
        }

        private void registraMessaggi()
        {
            Messenger.Default.Register<NotificationMessage>(this, ns =>
            {
                if (ns.Notification == "ApriFattura")
                {
                     new FatturaView().Show();
                }
                else if (ns.Notification == "ApriProdotti")
                {
                     new ProdottoView().Show();
                }
                else if (ns.Notification == "ApriCategorie")
                {
                     new CategoriaView().Show();
                }
            });
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Bootstrap.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }
    }
}