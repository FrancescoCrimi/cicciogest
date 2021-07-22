using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.View
{
    public partial class ListaArticoliView : Page
    {
        public ListaArticoliView(ListaArticoliViewModel listaArticoliViewModel)
        {
            InitializeComponent();
            DataContext = listaArticoliViewModel;
        }
    }
}
