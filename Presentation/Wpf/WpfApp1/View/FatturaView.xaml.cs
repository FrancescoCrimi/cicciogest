using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FatturaView : Window
    {
        private readonly FatturaViewModel fatturaViewModel;

        public FatturaView(FatturaViewModel fatturaViewModel)
        {
            InitializeComponent();
            DataContext = fatturaViewModel;
            this.fatturaViewModel = fatturaViewModel;
            fatturaViewModel.OnRequestClose += FatturaViewModel_OnRequestClose;
        }

        private void FatturaViewModel_OnRequestClose(object sender, EventArgs e)
        {
            fatturaViewModel.OnRequestClose -= FatturaViewModel_OnRequestClose;
            Close();
        }
    }
}
