using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class CategoriaView : Window
    {
        public CategoriaView()
        {
            InitializeComponent();
            Closing += CategoriaView_Closing;
        }

        private void CategoriaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            Bootstrap.Windsor.Release(DataContext);
        }
    }
}