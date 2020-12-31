using CiccioGest.Presentation.WpfApp1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class ListaArticoliView : Window, IView
    {
        public ListaArticoliView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.ListaArticoli;
    }
}
