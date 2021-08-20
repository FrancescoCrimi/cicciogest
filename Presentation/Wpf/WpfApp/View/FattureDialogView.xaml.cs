using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FattureDialogView : Page
    {
        public FattureDialogView(FattureDialogViewModel fattureDialogViewModel)
        {
            InitializeComponent();
            DataContext = fattureDialogViewModel;
        }
    }
}
