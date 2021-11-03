using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ListaClientiView : Page
    {
        public ListaClientiView(ListaClientiViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
