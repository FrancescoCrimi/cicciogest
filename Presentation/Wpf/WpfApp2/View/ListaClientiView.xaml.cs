using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.View
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
