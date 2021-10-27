using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class FattureListView : Page
    {
        public FattureListView(FattureListViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
