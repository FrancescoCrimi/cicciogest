using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ListaClientiView : Page
    {
        public ListaClientiView(ListaClientiViewModel clientiDialogViewModel)
        {
            InitializeComponent();
            DataContext = clientiDialogViewModel;
        }
    }
}
