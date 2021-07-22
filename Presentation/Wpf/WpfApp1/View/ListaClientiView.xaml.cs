using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class ListaClientiView : Window
    {
        public ListaClientiView(ListaClientiViewModel listaClientiViewModel)
        {
            InitializeComponent();
            DataContext = listaClientiViewModel;
        }
    }
}
