using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf.View
{
    /// <summary>
    /// Description for FatturaView.
    /// </summary>
    public partial class FatturaView : Window
    {
        /// <summary>
        /// Initializes a new instance of the FatturaView class.
        /// </summary>
        public FatturaView()
        {
            InitializeComponent();
            registramessaggi();
            Closing += FatturaView_Closing;
        }

        private void registramessaggi()
        {
            Messenger.Default.Register<NotificationMessage>(this, ns =>
            {
                if (ns.Notification == "SelezionaProdotto")
                {
                    new SelezionaProdottoView().ShowDialog();
                }
                else if (ns.Notification == "SelezionaFattura")
                {
                    new SelezionaFatturaView().ShowDialog();
                }
            });
        }

        private void FatturaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            Bootstrap.Windsor.Release(DataContext);
        }
    }
}