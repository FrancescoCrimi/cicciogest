using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class ListaArticoliView : Window
    {
        public ListaArticoliView(ListaArticoliViewModel listaArticoliViewModel)
        {
            InitializeComponent();
            DataContext = listaArticoliViewModel;
        }
    }
}
