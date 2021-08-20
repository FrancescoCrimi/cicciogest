using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class FatturaView : Page
    {
        public FatturaView(FatturaViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
