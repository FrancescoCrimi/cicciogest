using CiccioGest.Presentation.Wpf.App2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
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
