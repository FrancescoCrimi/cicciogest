using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
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
