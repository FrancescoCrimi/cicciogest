using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ClientiListView : Page
    {
        public ClientiListView(ClientiListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
