using CiccioGest.Presentation.Wpf.App2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class ListaClientiView : Window, IView
    {
        public ListaClientiView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.ListaClienti;
    }
}
