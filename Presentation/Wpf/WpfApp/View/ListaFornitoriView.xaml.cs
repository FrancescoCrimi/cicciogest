using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ListaFornitoriView : Page
    {
        public ListaFornitoriView(ListaFornitoriViewModel fornitoriListViewModel)
        {
            InitializeComponent();
            DataContext = fornitoriListViewModel;
        }
    }
}
