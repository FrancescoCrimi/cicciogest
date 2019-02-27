using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf.View
{
    /// <summary>
    /// Description for ProdottoView.
    /// </summary>
    public partial class ProdottoView : Window
    {
        /// <summary>
        /// Initializes a new instance of the ProdottoView class.
        /// </summary>
        public ProdottoView()
        {
            InitializeComponent();
            Closing += ProdottoView_Closing;
        }

        private void ProdottoView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            Bootstrap.Windsor.Release(DataContext);
        }
    }
}