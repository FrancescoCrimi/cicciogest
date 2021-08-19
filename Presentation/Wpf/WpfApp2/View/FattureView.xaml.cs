using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FattureView : Page
    {
        public FattureView(FattureViewModel fattureViewModel)
        {
            InitializeComponent();
            DataContext = fattureViewModel;
        }
    }
}
