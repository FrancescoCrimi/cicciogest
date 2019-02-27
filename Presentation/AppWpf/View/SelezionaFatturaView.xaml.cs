using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf.View
{
    /// <summary>
    /// Description for SelezionaFatturaView.
    /// </summary>
    public partial class SelezionaFatturaView : Window
    {
        /// <summary>
        /// Initializes a new instance of the SelezionaFatturaView class.
        /// </summary>
        public SelezionaFatturaView()
        {
            InitializeComponent();
            Closing += SelezionaFatturaView_Closing;
        }

        private void SelezionaFatturaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            Bootstrap.Windsor.Release(DataContext);
        }
    }
}