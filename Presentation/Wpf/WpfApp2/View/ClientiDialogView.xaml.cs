using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClientiDialogView : Page
    {
        public ClientiDialogView(ClientiDialogViewModel clientiDialogViewModel)
        {
            InitializeComponent();
            DataContext = clientiDialogViewModel;
        }
    }
}
