using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ListaFattureView : Page
    {
        public ListaFattureView(ListaFattureViewModel fattureDialogViewModel)
        {
            InitializeComponent();
            DataContext = fattureDialogViewModel;
        }
    }
}
