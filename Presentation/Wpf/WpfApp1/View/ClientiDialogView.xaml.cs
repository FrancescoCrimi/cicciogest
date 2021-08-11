using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClientiDialogView : Window
    {
        private readonly ClientiDialogViewModel clientiDialogViewModel;

        public ClientiDialogView(ClientiDialogViewModel clientiDialogViewModel)
        {
            InitializeComponent();
            this.clientiDialogViewModel = clientiDialogViewModel;
            DataContext = clientiDialogViewModel;
            clientiDialogViewModel.OnRequestClose += ClientiDialogViewModel_OnRequestClose;
        }

        private void ClientiDialogViewModel_OnRequestClose(object sender, EventArgs e)
        {
            clientiDialogViewModel.OnRequestClose -= ClientiDialogViewModel_OnRequestClose;
            Close();
        }
    }
}
