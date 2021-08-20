using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class FattureView : Page
    {
        public FattureView(FattureViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
