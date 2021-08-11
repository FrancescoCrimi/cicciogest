using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FattureView : Window
    {
        private readonly FattureViewModel fattureViewModel;

        public FattureView(FattureViewModel fattureViewModel)
        {
            InitializeComponent();
            DataContext = fattureViewModel;
            this.fattureViewModel = fattureViewModel;
            fattureViewModel.OnRequestClose += FattureViewModel_OnRequestClose;
        }

        private void FattureViewModel_OnRequestClose(object sender, EventArgs e)
        {
            fattureViewModel.OnRequestClose -= FattureViewModel_OnRequestClose;
            Close();
        }
    }
}
