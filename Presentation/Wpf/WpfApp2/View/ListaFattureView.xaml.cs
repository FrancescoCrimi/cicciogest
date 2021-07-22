using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.View
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
