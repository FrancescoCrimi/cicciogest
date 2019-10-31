﻿using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.AppWpfCore.View
{
    public partial class FatturaView : Window
    {
        public FatturaView()
        {
            InitializeComponent();
            Registramessaggi();
            Closing += FatturaView_Closing;
        }

        private void Registramessaggi()
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
            App.Windsor.Release(DataContext);
        }
    }
}