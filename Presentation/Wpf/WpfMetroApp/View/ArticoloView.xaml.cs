using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class ArticoloView : Page
    {
        public ArticoloView(ArticoloViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
