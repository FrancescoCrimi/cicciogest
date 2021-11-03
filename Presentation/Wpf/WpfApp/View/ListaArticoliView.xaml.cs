using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ListaArticoliView : Page
    {
        public ListaArticoliView(ListaArticoliViewModel articoliDialogViewModel)
        {
            InitializeComponent();
            DataContext = articoliDialogViewModel;
        }
    }
}
