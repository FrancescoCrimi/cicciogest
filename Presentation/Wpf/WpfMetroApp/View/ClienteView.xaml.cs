using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ClienteView : Page
    {
        public ClienteView(ClienteViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
