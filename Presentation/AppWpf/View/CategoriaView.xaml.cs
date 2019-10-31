﻿using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class CategoriaView : Page
    {
        public CategoriaView()
        {
            InitializeComponent();
            //Closing += CategoriaView_Closing;
        }

        private void CategoriaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
