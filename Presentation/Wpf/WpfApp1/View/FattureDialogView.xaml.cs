using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FattureDialogView : Window
    {
        private readonly FattureDialogViewModel fattureDialogViewModel;

        public FattureDialogView(FattureDialogViewModel fattureDialogViewModel)
        {
            InitializeComponent();
            this.fattureDialogViewModel = fattureDialogViewModel;
            DataContext = fattureDialogViewModel;
            fattureDialogViewModel.OnRequestClose += FattureDialogViewModel_OnRequestClose;
        }

        private void FattureDialogViewModel_OnRequestClose(object sender, EventArgs e)
        {
            fattureDialogViewModel.OnRequestClose -= FattureDialogViewModel_OnRequestClose;
            Close();
        }
    }
}
