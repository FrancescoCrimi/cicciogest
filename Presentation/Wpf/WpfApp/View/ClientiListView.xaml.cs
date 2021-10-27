using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClientiListView : Page
    {
        public ClientiListView(ClientiListViewModel clientiDialogViewModel)
        {
            InitializeComponent();
            DataContext = clientiDialogViewModel;
        }
    }
}
