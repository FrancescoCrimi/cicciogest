using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ListaFattureView : Page
    {
        public ListaFattureView(ListaFattureViewModel listaFattureViewModel)
        {
            InitializeComponent();
            DataContext = listaFattureViewModel;
        }
    }
}
