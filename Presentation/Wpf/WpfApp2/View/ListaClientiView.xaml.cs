using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ListaClientiView : Page
    {
        public ListaClientiView(ListaClientiViewModel listaClientiViewModel)
        {
            InitializeComponent();
            DataContext = listaClientiViewModel;
        }
    }
}
